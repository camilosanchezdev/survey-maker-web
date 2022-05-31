import { UserActions, UserActionTypes } from '../actions/user.actions'
import { UserState } from '../app.state'

const INITIAL_STATE: UserState = {
    name: '',
    email: '',
    createdAt: null,
}

export function userReducer(state: UserState = INITIAL_STATE, action: UserActions): UserState {
    switch (action.type) {
        case UserActionTypes.InitSetUser: {
            const auth: UserState = {
                name: action.payload.name,
                email: action.payload.email,
                createdAt: new Date(action.payload.createdAt),
            }
            return <UserState>Object.assign({}, state, auth)
        }

        default:
            return state
    }
}
