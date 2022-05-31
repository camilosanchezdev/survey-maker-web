import { Action } from '@ngrx/store'
import { ProfileModel } from 'src/app/shared/models/profile.model'

export enum UserActionTypes {
    InitUser = '[User] Init User',
    InitSetUser = '[User] Init Set User',
}

export class InitUserAction implements Action {
    readonly type = UserActionTypes.InitUser
    constructor() {}
}

export class SetUserAction implements Action {
    readonly type = UserActionTypes.InitSetUser
    constructor(public payload: ProfileModel) {}
}

export type UserActions = InitUserAction | SetUserAction
