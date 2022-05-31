import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { UserChangePasswordComponent } from './pages/user-change-password/user-change-password.component'
import { UserDashboardComponent } from './pages/user-dashboard/user-dashboard.component'
import { UserEditProfileComponent } from './pages/user-edit-profile/user-edit-profile.component'
import { UserProfileComponent } from './pages/user-profile/user-profile.component'
import { UserSettingsComponent } from './pages/user-settings/user-settings.component'
import { UserSurveysDetailComponent } from './pages/user-surveys/user-surveys-detail/user-surveys-detail.component'
import { UserSurveysEditComponent } from './pages/user-surveys/user-surveys-edit/user-surveys-edit.component'
import { UserSurveysListComponent } from './pages/user-surveys/user-surveys-list/user-surveys-list.component'
import { UserSurveysNewComponent } from './pages/user-surveys/user-surveys-new/user-surveys-new.component'
import { UserSurveysStatisticsComponent } from './pages/user-surveys/user-surveys-statistics/user-surveys-statistics.component'
import { UserComponent } from './user.component'

const routes: Routes = [
    {
        path: '',
        component: UserComponent,
        children: [
            {
                path: '',
                component: UserDashboardComponent,
            },
            {
                path: 'profile',
                component: UserProfileComponent,
            },
            {
                path: 'profile/edit',
                component: UserEditProfileComponent,
            },
            {
                path: 'profile/change-password',
                component: UserChangePasswordComponent,
            },
            {
                path: 'surveys',
                component: UserSurveysListComponent,
            },
            {
                path: 'surveys/new',
                component: UserSurveysNewComponent,
            },
            {
                path: 'surveys/:id',
                component: UserSurveysDetailComponent,
            },
            {
                path: 'surveys/:id/edit',
                component: UserSurveysEditComponent,
            },
            {
                path: 'surveys/:id/statistics',
                component: UserSurveysStatisticsComponent,
            },
            {
                path: 'settings',
                component: UserSettingsComponent,
            },
        ],
    },
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class UserRoutingModule {}
