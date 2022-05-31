import { Component, OnDestroy, OnInit } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { MatDialog } from '@angular/material/dialog'
import { MatSnackBar } from '@angular/material/snack-bar'
import { Router } from '@angular/router'
import { Subscription } from 'rxjs'
import { LoadingService } from 'src/app/core/services/loading.service'
import { UserSection } from 'src/app/shared/enums/user-section.enum'
import { QuestionModel } from 'src/app/shared/models/question.model'
import { SurveyModel } from 'src/app/shared/models/survey.model'
import { NewSurveyRequest } from 'src/app/shared/requests/new-survey.request'
import { UserService } from 'src/app/shared/services/user.service'
import { UiAddQuestionComponent } from '../../../components/ui/ui-add-question/ui-add-question.component'

@Component({
    selector: 'app-user-surveys-new',
    templateUrl: './user-surveys-new.component.html',
    styleUrls: ['./user-surveys-new.component.scss'],
})
export class UserSurveysNewComponent implements OnInit, OnDestroy {
    private subscriptions = new Subscription()
    formGroup: FormGroup
    questions: Array<QuestionModel> = new Array<QuestionModel>()
    SECTION = UserSection

    constructor(
        public dialog: MatDialog,
        private fb: FormBuilder,
        private userService: UserService,
        private loading: LoadingService,
        private router: Router,
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
                this.userService.createSurvey(this.createRequest()).subscribe({
                    next: (response: SurveyModel) => {
                        this.loading.hide()
                        this.router.navigate(['/main/surveys/', response.id])
                    },
                    error: (error: any) => {
                        this.loading.hide()
                        this.snackBar.open(error.title, error.detail, { duration: 1000 })
                    },
                })
            )
        }
    }
    onSaveAsDraft(): void {
        if (this.formGroup.valid) {
            this.loading.show()
            this.subscriptions.add(
                this.userService.createSurveyAsDraft(this.createRequest()).subscribe({
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
