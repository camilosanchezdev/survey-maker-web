import { Component, OnDestroy, OnInit } from '@angular/core'
import { MatSnackBar } from '@angular/material/snack-bar'
import { ActivatedRoute, Router } from '@angular/router'
import { Subscription } from 'rxjs'
import { LoadingService } from 'src/app/core/services/loading.service'
import { SurveyStatus } from 'src/app/shared/enums/survey-status.enum'
import { SurveyModel } from 'src/app/shared/models/survey.model'
import { UserService } from 'src/app/shared/services/user.service'
import { downloadExcel } from 'src/app/shared/utils/functions'
import { UserSection } from 'src/app/shared/enums/user-section.enum'
@Component({
    selector: 'app-user-surveys-detail',
    templateUrl: './user-surveys-detail.component.html',
    styleUrls: ['./user-surveys-detail.component.scss'],
})
export class UserSurveysDetailComponent implements OnInit, OnDestroy {
    private subscriptions = new Subscription()
    surveyId: number
    survey: SurveyModel
    SURVEY_STATUS = SurveyStatus
    SECTION = UserSection
    constructor(
        private route: ActivatedRoute,
        private userService: UserService,
        private loading: LoadingService,
        private router: Router,
        private snackBar: MatSnackBar
    ) {}
    ngOnDestroy(): void {
        this.subscriptions.unsubscribe()
    }

    ngOnInit(): void {
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
                },
            })
        )
    }
    onMarkAsActive(): void {
        this.loading.show()
        this.subscriptions.add(
            this.userService.markSurveyAsActive(this.surveyId).subscribe({
                error: (error: any) => {
                    this.loading.hide()
                    this.snackBar.open(error.title, error.detail, { duration: 5000 })
                },
                next: (survey) => {
                    this.loading.hide()
                    this.survey = survey
                },
            })
        )
    }
    onMarkAsCompleted(): void {
        this.loading.show()
        this.subscriptions.add(
            this.userService.markSurveyAsCompleted(this.surveyId).subscribe({
                error: (error: any) => {
                    this.loading.hide()
                    this.snackBar.open(error.title, error.detail, { duration: 5000 })
                },
                next: (survey) => {
                    this.loading.hide()
                    this.survey = survey
                },
            })
        )
    }
    onDownloadReport(): void {
        const reportTitle =
            'report-' +
            this.survey?.title
                .toLocaleLowerCase()
                .replace(/[^\w\s]/gi, '') //Remove all special characters
                .split(' ')
                .join('-') +
            '.xlsx'
        this.loading.show()
        this.subscriptions.add(
            this.userService.downloadReport(this.surveyId).subscribe({
                error: (error: any) => {
                    this.loading.hide()
                    this.snackBar.open(error.title, error.detail, { duration: 5000 })
                },
                next: (response) => {
                    this.loading.hide()
                    downloadExcel(response, reportTitle)
                },
            })
        )
    }
    openStatistics(): void {
        const url = `/main/surveys/${this.surveyId}/statistics`
        this.router.navigate([url])
    }
    copyLink(link: string): void {
        const publicLink = `${location.origin}/survey/${link}`
        navigator.clipboard.writeText(publicLink)
        this.snackBar.open('Copied link', '', { duration: 1000 })
    }
    editSurvey(): void {
        const url = `/main/surveys/${this.surveyId}/edit`
        this.router.navigate([url])
    }
}
