import { ApiExceptionTypeEnum } from '../enums/api-exception-type.enum'
import { BaseError } from './base-error'

export class ApiError extends BaseError {
    url: string
    exception: ApiExceptionTypeEnum
    exceptionName: string
    constructor(url: string, exception: ApiExceptionTypeEnum, title?: string, detail?: string, exceptionName?: string) {
        super()
        this.url = url
        this.exception = exception
        this.title = title
        this.detail = detail
        this.exceptionName = exceptionName
    }
}
