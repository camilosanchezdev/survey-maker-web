import { createFeatureSelector, createSelector, MemoizedSelector } from '@ngrx/store'
import { ProfileModel } from 'src/app/shared/models/profile.model'
import { AuthState, UserState } from '../app.state'

export const selectAuth = createFeatureSelector<AuthState>('auth')
export const getToken = (): MemoizedSelector<object, string> => createSelector(selectAuth, (state: AuthState) => state.token)

export const isLoggedIn = (): MemoizedSelector<object, boolean> => createSelector(selectAuth, (state: AuthState) => state.isAuthenticated)
