import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { UserComponent } from './user.component'
import { UserDashboardComponent } from './pages/user-dashboard/user-dashboard.component'
import { UserProfileComponent } from './pages/user-profile/user-profile.component'
import { UserSurveysListComponent } from './pages/user-surveys/user-surveys-list/user-surveys-list.component'
import { UserSurveysNewComponent } from './pages/user-surveys/user-surveys-new/user-surveys-new.component'
import { UserSurveysEditComponent } from './pages/user-surveys/user-surveys-edit/user-surveys-edit.component'
import { UserSurveysDetailComponent } from './pages/user-surveys/user-surveys-detail/user-surveys-detail.component'
import { UserRoutingModule } from './user-routing.module'
import { SidenavComponent } from './components/layout/sidenav/sidenav.component'
import { SharedModule } from 'src/app/shared/shared.module'
import { ToolbarComponent } from './components/layout/toolbar/toolbar.component'
import { UiNavButtonComponent } from './components/ui/ui-nav-button/ui-nav-button.component'
import { UserSettingsComponent } from './pages/user-settings/user-settings.component'
import { UiDashboardCardComponent } from './components/ui/ui-dashboard-card/ui-dashboard-card.component'
import { UiSurveysItemComponent } from './components/ui/ui-surveys-item/ui-surveys-item.component'
import { UiAddQuestionComponent } from './components/ui/ui-add-question/ui-add-question.component'
import { UiBarChartComponent } from './components/ui/ui-bar-chart/ui-bar-chart.component'
import { UserSurveysStatisticsComponent } from './pages/user-surveys/user-surveys-statistics/user-surveys-statistics.component'
import { UserEditProfileComponent } from './pages/user-edit-profile/user-edit-profile.component'
import { UserChangePasswordComponent } from './pages/user-change-password/user-change-password.component'
import { UiBreadcrumbsComponent } from './components/ui/ui-breadcrumbs/ui-breadcrumbs.component'
import { StoreModule } from '@ngrx/store'
import { EffectsModule } from '@ngrx/effects'
import { UserEffects } from 'src/app/core/state/effects/user.effects'
import { userReducer } from 'src/app/core/state/reducers/user.reducer'

@NgModule({
    declarations: [
        UserComponent,
        UserDashboardComponent,
        UserProfileComponent,
        UserSurveysListComponent,
        UserSurveysNewComponent,
        UserSurveysEditComponent,
        UserSurveysDetailComponent,
        SidenavComponent,
        ToolbarComponent,
        UiNavButtonComponent,
        UserSettingsComponent,
        UiDashboardCardComponent,
        UiSurveysItemComponent,
        UiAddQuestionComponent,
        UiBarChartComponent,
        UserSurveysStatisticsComponent,
        UserEditProfileComponent,
        UserChangePasswordComponent,
        UiBreadcrumbsComponent,
    ],
    imports: [UserRoutingModule, SharedModule, StoreModule.forFeature('user', userReducer), EffectsModule.forFeature([UserEffects])],
})
export class UserModule {}
