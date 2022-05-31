import { Injectable } from '@angular/core'
import { select, Store } from '@ngrx/store'
import { Observable } from 'rxjs'
import { map, switchMap, take } from 'rxjs/operators'
import { UserApi } from 'src/app/shared/api/user.api'
import { AuthRequest } from 'src/app/shared/requests/auth.request'
import { RegisterRequest } from 'src/app/shared/requests/register.request'
import { LoginAction, LogoutAction } from '../state/actions/auth.actions'
import { AppState } from '../state/app.state'
import { getToken, isLoggedIn } from '../state/selectors/auth.selector'

@Injectable({ providedIn: 'root' })
export class AuthService {
    constructor(private userApi: UserApi, private store: Store<AppState>) {}
    login(body: AuthRequest) {
        return this.userApi.login(body).pipe(
            map((response) => {
                this.store.dispatch(new LoginAction(response))
                return response
            })
        )
    }
    logout() {
        this.store.dispatch(new LogoutAction())
    }

    getCurrentToken(): Observable<string> {
        return this.store.pipe(select(getToken()), take(1))
    }
    register(body: RegisterRequest) {
        return this.userApi.register(body).pipe(
            switchMap(() => {
                const request: AuthRequest = { email: body.email, password: body.password }
                return this.userApi.login(request).pipe(
                    map((response) => {
                        this.store.dispatch(new LoginAction(response))
                        return response
                    })
                )
            })
        )
    }
    isLoggedIn(): Observable<boolean> {
        return this.store.pipe(select(isLoggedIn()))
    }
}
