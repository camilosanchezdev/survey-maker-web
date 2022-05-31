import { AuthActions, AuthActionTypes } from '../actions/auth.actions'
import { AuthState } from '../app.state'

const INITIAL_STATE: AuthState = {
    isAuthenticated: false,
    token: '',
}
export function authReducer(state: AuthState = INITIAL_STATE, action: AuthActions): AuthState {
    switch (action.type) {
        case AuthActionTypes.Login: {
            const auth: AuthState = {
                isAuthenticated: true,
                token: action.payload.token,
            }
            return <AuthState>Object.assign({}, state, auth)
        }
        case AuthActionTypes.SetAuthData: {
            const auth: AuthState = {
                isAuthenticated: true,
                token: action.payload.token,
            }
            return <AuthState>Object.assign({}, state, auth)
        }
        case AuthActionTypes.ClearAuthData: {
            return INITIAL_STATE
        }
        default: {
            return state
        }
    }
}
