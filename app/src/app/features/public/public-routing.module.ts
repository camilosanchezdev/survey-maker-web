import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { PublicGuard } from 'src/app/core/guards/public.guard'
import { HomeComponent } from './home/home.component'
import { LoginComponent } from './login/login.component'
import { PublicComponent } from './public.component'
import { RegisterComponent } from './register/register.component'
import { SuccessComponent } from './success/success.component'
import { SurveyComponent } from './survey/survey.component'

const routes: Routes = [
    {
        path: '',
        component: PublicComponent,
        children: [
            {
                path: '',
                component: HomeComponent,
            },
            {
                path: 'survey/:id',
                component: SurveyComponent,
                canActivate: [PublicGuard],
            },
            {
                path: 'success',
                component: SuccessComponent,
            },
            {
                path: 'login',
                component: LoginComponent,
            },
            {
                path: 'register',
                component: RegisterComponent,
            },
        ],
    },
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class PublicRoutingModule {}
