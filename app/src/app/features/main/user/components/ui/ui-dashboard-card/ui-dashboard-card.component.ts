import { Component, Input, OnInit } from '@angular/core'

@Component({
    selector: 'ui-dashboard-card',
    templateUrl: './ui-dashboard-card.component.html',
    styleUrls: ['./ui-dashboard-card.component.scss'],
})
export class UiDashboardCardComponent implements OnInit {
    @Input() title: string
    @Input() quantity: number
    @Input() subtitle: string
    @Input() icon: string
    @Input() text: string
    constructor() {}

    ngOnInit(): void {}
}
