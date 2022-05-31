import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { MaterialModule } from './material/material.module'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { UiLoadingComponent } from './components/ui/ui-loading/ui-loading.component'
import { SurveyStatusPipe } from './pipes/survey-status.pipe'

@NgModule({
    declarations: [UiLoadingComponent, SurveyStatusPipe],
    imports: [MaterialModule],
    exports: [CommonModule, MaterialModule, ReactiveFormsModule, FormsModule, UiLoadingComponent, SurveyStatusPipe],
})
export class SharedModule {}
