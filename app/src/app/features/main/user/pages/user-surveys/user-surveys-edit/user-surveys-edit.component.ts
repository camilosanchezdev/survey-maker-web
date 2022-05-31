import { asNativeElements, Component, OnDestroy, OnInit } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { MatDialog } from '@angular/material/dialog'
import { MatSnackBar } from '@angular/material/snack-bar'
import { ActivatedRoute, Router } from '@angular/router'
import { Subscription } from 'rxjs'
import { LoadingService } from 'src/app/core/services/loading.service'
import { UserSection } from 'src/app/shared/enums/user-section.enum'
import { QuestionModel } from 'src/app/shared/models/question.model'
import { SurveyModel } from 'src/app/shared/models/survey.model'
import { NewSurveyRequest } from 'src/app/shared/requests/new-survey.request'
import { UserService } from 'src/app/shared/services/user.service'
import { UiAddQuestionComponent } from '../../../components/ui/ui-add-question/ui-add-question.component'

@Component({
    selector: 'app-user-surveys-edit',
    templateUrl: './user-surveys-edit.component.html',
    styleUrls: ['./user-surveys-edit.component.scss'],
})
export class UserSurveysEditComponent implements OnInit, OnDestroy {
    private subscriptions = new Subscription()
    formGroup: FormGroup
    questions: Array<QuestionModel> = new Array<QuestionModel>()
    SECTION = UserSection
    surveyId: number
    survey: SurveyModel

    constructor(
        public dialog: MatDialog,
        private fb: FormBuilder,
        private userService: UserService,
        private loading: LoadingService,
        private router: Router,
        private route: ActivatedRoute,
        private snackBar: MatSnackBar
    ) {}
    ngOnDestroy(): void {
        this.subscriptions.unsubscribe()
    }

    ngOnInit(): void {
        this.formGroup = this.fb.group({
            title: [null, Validators.required],
            description: [null, Validators.required],
            endsAt: [null, Validators.required],
        })
        this.getSurvey()
    }
    getSurvey(): void {
        this.surveyId = Number(this.route.snapshot.paramMap.get('id'))
        this.loading.show()
        this.subscriptions.add(
            this.userService.getSurvey(this.surveyId).subscribe({
                error: (error: any) => {
                    this.loading.hide()
                    this.snackBar.open(error.title, error.detail, { duration: 5000 })
                },
                next: (survey) => {
                    this.loading.hide()
                    this.survey = survey
                    this.setSurvey()
                },
            })
        )
    }
    setSurvey(): void {
        this.formGroup.get('title').setValue(this.survey.title)
        this.formGroup.get('description').setValue(this.survey.description)
        this.formGroup.get('endsAt').setValue(this.survey.endsAt)
        this.survey.questions.forEach((question) => {
            const questionToAdd: QuestionModel = {
                id: question.id,
                name: question.name,
                multiple: question.multiple,
                answers: question.answers,
            }
            this.questions.push(questionToAdd)
        })
    }
    onAddQuestion(): void {
        const dialogRef = this.dialog.open(UiAddQuestionComponent, {
            width: '40%',
        })

        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this.questions.push(result)
            }
        })
    }

    editQuestion(question: QuestionModel, index: number): void {
        const dialogRef = this.dialog.open(UiAddQuestionComponent, {
            width: '40%',
            data: question,
        })

        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this.questions[index] = result
            }
        })
    }
    removeQuestion(index: number): void {
        this.questions.splice(index, 1)
    }

    onSave(): void {
        if (this.formGroup.valid) {
            this.loading.show()
            this.subscriptions.add(
                this.userService.editSurvey(this.surveyId, this.createRequest()).subscribe({
                    next: (response: SurveyModel) => {
                        this.loading.hide()
                        this.router.navigate(['/main/surveys/', response.id])
                    },
                    error: (error: any) => {
                        this.loading.hide()
                        this.snackBar.open(error.title, error.detail, { duration: 5000 })
                    },
                })
            )
        }
    }
    onSaveAsDraft(): void {
        if (this.formGroup.valid) {
            this.loading.show()
            this.subscriptions.add(
                this.userService.editSurveyAsDraft(this.surveyId, this.createRequest()).subscribe({
                    next: (response: SurveyModel) => {
                        this.loading.hide()
                        this.router.navigate(['/main/surveys/', response.id])
                    },
                    error: (error: any) => {
                        this.loading.hide()
                        this.snackBar.open(error.title, error.detail, { duration: 5000 })
                    },
                })
            )
        }
    }
    createRequest(): NewSurveyRequest {
        return {
            title: this.formGroup.controls.title.value,
            description: this.formGroup.controls.description.value,
            endsAt: this.formGroup.controls.endsAt.value,
            questions: this.questions,
            surveyTags: [1, 2],
        }
    }
}
