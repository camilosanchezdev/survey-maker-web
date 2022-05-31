import { Injectable } from '@angular/core'
import { Router } from '@angular/router'
import { Actions, createEffect, ofType } from '@ngrx/effects'
import { Action } from '@ngrx/store'
import { EMPTY, map, Observable, of, switchMap, tap } from 'rxjs'
import { LoginModel } from 'src/app/shared/models/login.model'
import { AuthService } from '../../services/auth.service'
import { AuthActionTypes, ClearAuthDataAction, LoginAction, LogoutAction, SetAuthDataAction } from '../actions/auth.actions'
import { Location } from '@angular/common'
import { UserApi } from 'src/app/shared/api/user.api'

@Injectable()
export class AuthEffects {
    constructor(private actions$: Actions, private router: Router, private authService: AuthService, private location: Location, private userApi: UserApi) {}
    init$: Observable<Action> = createEffect(() => {
        const authData = localStorage.getItem('surveymaker')
        let token
        if (authData) {
            try {
                token = <LoginModel>JSON.parse(authData)
            } catch (e) {
                console.error(e)
            }
        }

        if (token) {
            if (new Date(token.expirationDate) < new Date()) {
                this.authService.logout()
                return EMPTY
            }
            if (this.location.path() === '') {
                this.router.navigate(['/main'])
            }
            return of(new SetAuthDataAction(Object.assign(token)))
        } else {
            return EMPTY
        }
    })

    login$: Observable<Action> = createEffect(
        () =>
            this.actions$.pipe(
                ofType(AuthActionTypes.Login),
                map((response) => <LoginAction>response),
                tap((action) => {
                    localStorage.setItem('surveymaker', JSON.stringify(action.payload))
                    this.router.navigate(['/main'])
                })
            ),
        { dispatch: false }
    )
    logout$: Observable<Action> = createEffect(() =>
        this.actions$.pipe(
            ofType(AuthActionTypes.Logout),
            map((action) => <LogoutAction>action),
            switchMap(() => {
                localStorage.removeItem('surveymaker')
                this.router.navigate(['/'])
                return of(new ClearAuthDataAction())
            })
        )
    )
}
