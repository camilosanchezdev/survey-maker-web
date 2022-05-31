import { Component, OnDestroy, OnInit } from '@angular/core'
import { MatSnackBar } from '@angular/material/snack-bar'
import { Subscription } from 'rxjs'
import { LoadingService } from 'src/app/core/services/loading.service'
import { ProfileModel } from 'src/app/shared/models/profile.model'
import { UserStateService } from 'src/app/shared/services/user-state.service'

@Component({
    selector: 'app-user-profile',
    templateUrl: './user-profile.component.html',
    styleUrls: ['./user-profile.component.scss'],
})
export class UserProfileComponent implements OnInit, OnDestroy {
    private subscriptions = new Subscription()
    profile: ProfileModel

    constructor(private userStateService: UserStateService, private loading: LoadingService, private snackBar: MatSnackBar) {}
    ngOnDestroy(): void {
        this.subscriptions.unsubscribe()
    }

    ngOnInit(): void {
        this.loading.show()
        this.subscriptions.add(
            this.userStateService.getProfile().subscribe({
                error: (error: any) => {
                    this.loading.hide()
                    this.snackBar.open(error.title, error.detail, { duration: 5000 })
                },
                next: (response) => {
                    this.loading.hide()
                    this.profile = response
                },
            })
        )
    }
}
