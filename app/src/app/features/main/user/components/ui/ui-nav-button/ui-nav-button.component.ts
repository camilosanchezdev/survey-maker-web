import { Component, Input, OnInit } from '@angular/core'

@Component({
    selector: 'ui-nav-button',
    templateUrl: './ui-nav-button.component.html',
    styleUrls: ['./ui-nav-button.component.scss'],
})
export class UiNavButtonComponent implements OnInit {
    @Input() text: string
    @Input() link: string
    @Input() icon: string
    constructor() {}

    ngOnInit(): void {}
}
