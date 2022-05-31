import { Component, OnDestroy, OnInit } from '@angular/core'
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router'
import { Subscription } from 'rxjs'
import { LoadingService } from 'src/app/core/services/loading.service'
import { SurveyModel } from 'src/app/shared/models/survey.model'
import { SaveResponseRequest } from 'src/app/shared/requests/save-response.request'
import { PublicService } from 'src/app/shared/services/public.service'

@Component({
    selector: 'app-survey',
    templateUrl: './survey.component.html',
    styleUrls: ['./survey.component.scss'],
})
export class SurveyComponent implements OnInit, OnDestroy {
    private subscriptions = new Subscription()
    surveyLink: string
    survey: SurveyModel
    formGroup: FormGroup
    constructor(
        private route: ActivatedRoute,
        private publicService: PublicService,
        private loading: LoadingService,
        private fb: FormBuilder,
        private router: Router
    ) {}
    ngOnDestroy(): void {
        this.subscriptions.unsubscribe()
    }

    ngOnInit(): void {
        this.formGroup = this.fb.group({
            questions: this.fb.array([]),
        })
        this.surveyLink = this.route.snapshot.paramMap.get('id')
        this.loading.show()
        this.subscriptions.add(
            this.publicService.getSurveyByLink(this.surveyLink).subscribe({
                error: (error) => {
                    this.loading.hide()
                },
                next: (response: SurveyModel) => {
                    this.loading.hide()
                    this.survey = response
                    this.setForm()
                },
            })
        )
    }
    get questions(): FormArray {
        return this.formGroup.get('questions') as FormArray
    }
    setForm(): void {
        this.survey.questions.forEach((question) => {
            if (!question.multiple) {
                this.questions.push(
                    this.fb.group({
                        question: [question.id],
                        answer: [null],
                    })
                )
            } else {
                const answers = {}

                question.answers.forEach((y) => {
                    answers[y.id] = new FormControl(null)
                })
                this.questions.push(
                    this.fb.group({
                        question: [question.id],
                        answer: this.fb.group(answers),
                    })
                )
            }
        })
    }
    onSubmit(): void {
        this.loading.show()
        this.subscriptions.add(
            this.publicService.saveResponse(this.createRequest()).subscribe({
                error: (error: any) => {
                    this.loading.hide()
                },
                next: (response: any) => {
                    this.loading.hide()
                    this.publicService.surveyAnswered(this.surveyLink)
                    this.router.navigate(['/success'])
                },
            })
        )
    }
    createRequest(): SaveResponseRequest {
        const answers = []
        this.questions.value.forEach((x) => {
            if (isNaN(x.answer)) {
                answers.push({
                    questionId: x.question,
                    answerIds: Object.keys(x.answer)
                        .filter((y) => x.answer[y])
                        .map((x) => parseInt(x)),
                })
            } else {
                answers.push({
                    questionId: x.question,
                    answerIds: [x.answer],
                })
            }
        })
        return {
            link: this.surveyLink,
            answers,
        }
    }
}
