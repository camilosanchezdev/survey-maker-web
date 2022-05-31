import { Component, OnDestroy, OnInit } from '@angular/core'
import { forkJoin, of, Subscription } from 'rxjs'
import { debounce, debounceTime, switchMap } from 'rxjs/operators'
import { LoadingService } from 'src/app/core/services/loading.service'
import { SurveyStatus } from 'src/app/shared/enums/survey-status.enum'
import { UserSection } from 'src/app/shared/enums/user-section.enum'
import { SurveyModel } from 'src/app/shared/models/survey.model'
import { UserService } from 'src/app/shared/services/user.service'

@Component({
    selector: 'app-user-surveys-list',
    templateUrl: './user-surveys-list.component.html',
    styleUrls: ['./user-surveys-list.component.scss'],
})
export class UserSurveysListComponent implements OnInit, OnDestroy {
    private subscriptions = new Subscription()
    activeSurveys: SurveyModel[]
    draftSurveys: SurveyModel[]
    completedSurveys: SurveyModel[]
    SECTION = UserSection
    constructor(private userService: UserService, private loading: LoadingService) {}
    ngOnDestroy(): void {
        this.subscriptions.unsubscribe()
    }

    ngOnInit(): void {
        this.loading.show()
        this.subscriptions.add(
            // this.userService.getAllSurveys().subscribe((surveys) => {
            //     this.loading.hide()
            //     this.surveys = surveys
            // })
            forkJoin([
                this.userService.getSurveysByStatus(SurveyStatus.Active),
                this.userService.getSurveysByStatus(SurveyStatus.Draft),
                this.userService.getSurveysByStatus(SurveyStatus.Completed),
            ]).subscribe(([activeSurveys, draftSurveys, completedSurveys]) => {
                this.loading.hide()
                this.activeSurveys = activeSurveys
                this.draftSurveys = draftSurveys
                this.completedSurveys = completedSurveys
            })
        )
    }
}
