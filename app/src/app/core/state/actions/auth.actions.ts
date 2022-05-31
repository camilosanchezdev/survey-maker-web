import { Action } from '@ngrx/store'
import { LoginModel } from 'src/app/shared/models/login.model'

export enum AuthActionTypes {
    SetAuthData = '[Auth] Set Authentication Data',
    Login = '[Auth] Login ',
    Logout = '[Auth] Logout User',
    ClearAuthData = '[Auth] Clear Authentication Data',
}

export class LoginAction implements Action {
    readonly type = AuthActionTypes.Login
    constructor(public payload: LoginModel) {}
}

export class SetAuthDataAction implements Action {
    readonly type = AuthActionTypes.SetAuthData
    constructor(public payload: any) {}
}
export class LogoutAction implements Action {
    readonly type = AuthActionTypes.Logout
    constructor() {}
}

export class ClearAuthDataAction implements Action {
    readonly type = AuthActionTypes.ClearAuthData
    constructor() {}
}

export type AuthActions = LoginAction | SetAuthDataAction | LogoutAction | ClearAuthDataAction
