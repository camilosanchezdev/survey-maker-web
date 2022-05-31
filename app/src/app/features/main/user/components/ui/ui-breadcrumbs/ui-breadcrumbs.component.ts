import { Component, Input, OnInit } from '@angular/core'
import { UserSection } from 'src/app/shared/enums/user-section.enum'

@Component({
    selector: 'ui-breadcrumbs',
    templateUrl: './ui-breadcrumbs.component.html',
    styleUrls: ['./ui-breadcrumbs.component.scss'],
})
export class UiBreadcrumbsComponent implements OnInit {
    @Input() lastPage: string
    @Input() section: number
    @Input() surveyId: number
    @Input() surveyTitle: string
    SECTION = UserSection
    constructor() {}

    ngOnInit(): void {}
}
