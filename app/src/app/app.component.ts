import { ChangeDetectorRef, Component } from '@angular/core'
import { LoadingService } from './core/services/loading.service'

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
})
export class AppComponent {
    title = 'survey-maker'
    loading$ = this.loader.loading$
    constructor(public loader: LoadingService, private cdref: ChangeDetectorRef) {}

    ngAfterContentChecked() {
        this.cdref.detectChanges()
    }
}
