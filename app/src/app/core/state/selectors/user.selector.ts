import { createFeatureSelector, createSelector, MemoizedSelector } from '@ngrx/store'
import { ProfileModel } from 'src/app/shared/models/profile.model'
import { UserState } from '../app.state'

export const selectUser = createFeatureSelector<UserState>('user')
export const getProfile = (): MemoizedSelector<object, ProfileModel> =>
    createSelector(selectUser, (state: UserState) => ({ name: state.name, email: state.email, createdAt: state.createdAt }))
