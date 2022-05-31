import { Action } from '@ngrx/store'

export enum InitActionTypes {
    StartInitModule = '[Init] Started Init Module',
}

export class StartInitModuleAction implements Action {
    readonly type = InitActionTypes.StartInitModule
    constructor(public payload: string) {}
}
