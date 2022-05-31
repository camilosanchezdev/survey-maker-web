import { Component, EventEmitter, OnInit, Output } from '@angular/core'
import { AuthService } from 'src/app/core/services/auth.service'

@Component({
    selector: 'app-toolbar',
    templateUrl: './toolbar.component.html',
    styleUrls: ['./toolbar.component.scss'],
})
export class ToolbarComponent implements OnInit {
    @Output() toggleSidenav = new EventEmitter<void>()
    constructor(private authService: AuthService) {}

    ngOnInit(): void {}
    logout(): void {
        this.authService.logout()
    }
}
