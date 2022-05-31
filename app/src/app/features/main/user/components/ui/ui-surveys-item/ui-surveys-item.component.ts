import { Component, Input, OnInit } from '@angular/core'
import { SurveyModel } from 'src/app/shared/models/survey.model'

@Component({
    selector: 'ui-surveys-item',
    templateUrl: './ui-surveys-item.component.html',
    styleUrls: ['./ui-surveys-item.component.scss'],
})
export class UiSurveysItemComponent implements OnInit {
    @Input() survey: SurveyModel
    constructor() {}

    ngOnInit(): void {}
}
