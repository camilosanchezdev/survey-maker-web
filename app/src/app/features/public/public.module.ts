import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { PublicComponent } from './public.component'
import { HomeComponent } from './home/home.component'
import { PublicRoutingModule } from './public-routing.module'
import { SurveyComponent } from './survey/survey.component'
import { SharedModule } from 'src/app/shared/shared.module';
import { ToolbarComponent } from './components/layout/toolbar/toolbar.component';
import { SidenavComponent } from './components/layout/sidenav/sidenav.component';
import { SuccessComponent } from './success/success.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component'

@NgModule({
    declarations: [PublicComponent, HomeComponent, SurveyComponent, ToolbarComponent, SidenavComponent, SuccessComponent, LoginComponent, RegisterComponent],
    imports: [CommonModule, PublicRoutingModule, SharedModule],
})
export class PublicModule {}
