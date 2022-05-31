import { Component, OnDestroy, OnInit } from '@angular/core'
import { MatSnackBar } from '@angular/material/snack-bar'
import { ActivatedRoute } from '@angular/router'
import { Subscription } from 'rxjs'
import { LoadingService } from 'src/app/core/services/loading.service'
import { UserSection } from 'src/app/shared/enums/user-section.enum'
import { ReportModel } from 'src/app/shared/models/report.model'
import { UserService } from 'src/app/shared/services/user.service'

@Component({
    selector: 'app-user-surveys-statistics',
    templateUrl: './user-surveys-statistics.component.html',
    styleUrls: ['./user-surveys-statistics.component.scss'],
})
export class UserSurveysStatisticsComponent implements OnInit, OnDestroy {
    subscriptions = new Subscription()
    surveyId: number
    report: ReportModel
    SECTION = UserSection

    constructor(private userService: UserService, private route: ActivatedRoute, private loading: LoadingService, private snackBar: MatSnackBar) {}
    ngOnDestroy(): void {}

    ngOnInit(): void {
        this.surveyId = Number(this.route.snapshot.paramMap.get('id'))
        this.loading.show()
        this.subscriptions.add(
            this.userService.getStatistics(this.surveyId).subscribe({
                error: (error: any) => {
                    this.loading.hide()
                    this.snackBar.open(error.title, error.detail, { duration: 5000 })
                },
                next: (response) => {
                    this.loading.hide()
                    this.report = response
                },
            })
        )
    }
}
