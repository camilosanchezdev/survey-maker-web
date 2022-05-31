import { Injectable } from '@angular/core'
import { Store } from '@ngrx/store'
import { StartInitModuleAction } from '../state/actions/init.action'
import { AppState } from '../state/app.state'

@Injectable({ providedIn: 'root' })
export class InitService {
    constructor(private store: Store<AppState>) {}

    startInitModule(name: string) {
        this.store.dispatch(new StartInitModuleAction(name))
    }
}
