import { Injectable } from '@angular/core'
import { select, Store } from '@ngrx/store'
import { Observable, of } from 'rxjs'
import { SetUserAction } from 'src/app/core/state/actions/user.actions'
import { AppState } from 'src/app/core/state/app.state'
import { getProfile } from 'src/app/core/state/selectors/user.selector'
import { ProfileModel } from '../models/profile.model'

@Injectable({ providedIn: 'root' })
export class UserStateService {
    constructor(private store: Store<AppState>) {}

    getProfile(): Observable<ProfileModel> {
        return this.store.pipe(select(getProfile()))
    }
    setProfile(profile: ProfileModel) {
        return this.store.dispatch(new SetUserAction(profile))
    }
}
