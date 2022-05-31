import { Component, OnInit } from '@angular/core'
import { FormGroup } from '@angular/forms'
import { UserSection } from 'src/app/shared/enums/user-section.enum'

@Component({
    selector: 'app-user-settings',
    templateUrl: './user-settings.component.html',
    styleUrls: ['./user-settings.component.scss'],
})
export class UserSettingsComponent implements OnInit {
    SECTION = UserSection
    constructor() {}

    ngOnInit(): void {}
}
