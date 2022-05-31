import { HttpMethodEnum } from '../enums/http-method.enum'

export class NetworkRequest {
    url: string
    httpMethod: HttpMethodEnum
    jsonBody: any
    retryNumber: number
    retryTime: number
    responseType: any

    constructor(url: string, httpMethod: HttpMethodEnum, jsonBody?: any, retryNumber?: number, retryTime?: number, responseType?: any) {
        this.url = url
        this.httpMethod = httpMethod
        this.jsonBody = jsonBody
        this.retryTime = retryTime ?? 1500
        this.retryNumber = retryNumber ?? 2
        this.responseType = responseType
    }
}
