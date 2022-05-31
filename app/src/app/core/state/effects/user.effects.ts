import { Injectable } from '@angular/core'
import { Actions, createEffect, ofType } from '@ngrx/effects'
import { Action } from '@ngrx/store'
import { catchError, filter, map, Observable, of, switchMap } from 'rxjs'
import { UserApi } from 'src/app/shared/api/user.api'
import { LoadingService } from '../../services/loading.service'
import { InitActionTypes, StartInitModuleAction } from '../actions/init.action'
import { SetUserAction, InitUserAction, UserActionTypes } from '../actions/user.actions'

@Injectable()
export class UserEffects {
    constructor(private actions$: Actions, private userApi: UserApi, private loading: LoadingService) {}
    startInitAction$: Observable<Action> = createEffect(() =>
        this.actions$.pipe(
            ofType(InitActionTypes.StartInitModule),
            map((action) => <StartInitModuleAction>action),
            filter((action) => action.payload === 'UserModule'),
            switchMap(() => of(new InitUserAction()))
        )
    )

    initUser$: Observable<Action> = createEffect(() =>
        this.actions$.pipe(
            ofType(UserActionTypes.InitUser),
            map((action) => <InitUserAction>action),
            switchMap(() =>
                this.userApi.getUser().pipe(
                    map(
                        (response) => {
                            this.loading.hide()
                            return new SetUserAction(response)
                        },
                        catchError((error) => {
                            this.loading.hide()
                            return of(error)
                        })
                    )
                )
            )
        )
    )
}
