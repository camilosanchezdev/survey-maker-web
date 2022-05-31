export interface AppState {
    auth: AuthState
}

export interface AuthState {
    isAuthenticated: boolean
    token: string
}

export interface UserState {
    name: string
    email: string
    createdAt: Date
}
