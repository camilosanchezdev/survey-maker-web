import { ErrorMessageModel } from './error-message.model'

export const ERROR_MESSAGES_UNAUTHORIZED: ErrorMessageModel = {
    title: 'Authentication Error',
    message: 'Incorrect email and / or password',
}

export const ERROR_MESSAGES_ALREADY_EXISTS: ErrorMessageModel = {
    title: 'Email Address already taken',
    message: 'It looks like you already have an account with this email',
}
export const DEFAULT_SERVER_ERROR: ErrorMessageModel = {
    title: 'Server Error',
    message: 'Please try again',
}
