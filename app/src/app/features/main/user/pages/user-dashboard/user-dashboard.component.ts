import { Component, OnDestroy, OnInit } from '@angular/core'
import { MatSnackBar } from '@angular/material/snack-bar'
import { Subscription } from 'rxjs'
import { LoadingService } from 'src/app/core/services/loading.service'
import { KpiModel } from 'src/app/shared/models/kpi.model'
import { UserService } from 'src/app/shared/services/user.service'

@Component({
    selector: 'app-user-dashboard',
    templateUrl: './user-dashboard.component.html',
    styleUrls: ['./user-dashboard.component.scss'],
})
export class UserDashboardComponent implements OnInit, OnDestroy {
    private subscriptions = new Subscription()
    kpis: KpiModel
    constructor(private userService: UserService, private loading: LoadingService, private snackBar: MatSnackBar) {}
    ngOnDestroy(): void {
        this.subscriptions.unsubscribe()
    }

    ngOnInit(): void {
        this.loading.show()
        this.subscriptions.add(
            this.userService.getKpis().subscribe({
                error: (error: any) => {
                    this.loading.hide()
                    this.snackBar.open(error.title, error.detail, { duration: 5000 })
                },
                next: (response) => {
                    this.loading.hide()
                    this.kpis = response
                },
            })
        )
    }
}
