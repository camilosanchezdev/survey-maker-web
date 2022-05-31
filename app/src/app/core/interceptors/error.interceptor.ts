import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HTTP_INTERCEPTORS } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { catchError, Observable, throwError } from 'rxjs'
import { ApiError } from '../classes/api-error'
import { ErrorMessageModel } from '../config/error-message.model'
import { DEFAULT_SERVER_ERROR, ERROR_MESSAGES_ALREADY_EXISTS, ERROR_MESSAGES_UNAUTHORIZED } from '../config/error-messages'
import { ApiExceptionTypeEnum } from '../enums/api-exception-type.enum'

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor() {}
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError((err) => {
                let error: ApiExceptionTypeEnum
                let message: ErrorMessageModel
                let exception: string
                switch (err?.status) {
                    case 400:
                        message = DEFAULT_SERVER_ERROR
                        error = ApiExceptionTypeEnum.BadRequest
                        exception = err.error.Exception
                        break
                    case 401:
                        message = ERROR_MESSAGES_UNAUTHORIZED
                        error = ApiExceptionTypeEnum.Unauthorized
                        exception = err.error.Exception
                        break
                    case 403:
                        message = DEFAULT_SERVER_ERROR
                        error = ApiExceptionTypeEnum.ForbiddenException
                        exception = err.error.Exception
                        break
                    case 404:
                        message = DEFAULT_SERVER_ERROR
                        error = ApiExceptionTypeEnum.NotFound
                        exception = err.error.Exception
                        break
                    case 409:
                        message = ERROR_MESSAGES_ALREADY_EXISTS
                        error = ApiExceptionTypeEnum.AlreadyExists
                        exception = err.error.Exception
                        break
                    case 500:
                        message = DEFAULT_SERVER_ERROR
                        error = ApiExceptionTypeEnum.ServerError
                        break
                    default:
                        message = DEFAULT_SERVER_ERROR
                        error = ApiExceptionTypeEnum.ServerError
                        break
                }
                return throwError(new ApiError(err.url, error, message.title, message.message, exception))
            })
        )
    }
}

export let errorInterceptorProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true,
}
