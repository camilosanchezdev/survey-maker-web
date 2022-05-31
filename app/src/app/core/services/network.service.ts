import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable, of, throwError } from 'rxjs'
import { retryWhen, mergeMap, delay, shareReplay } from 'rxjs/operators'

import { NetworkRequest } from '../classes/network-request.class'
import { HttpMethodEnum } from '../enums/http-method.enum'

@Injectable({ providedIn: 'root' })
export class NetworkService {
    constructor(private httpClient: HttpClient) {}

    private getRequest(networkRequest: NetworkRequest): Observable<any> {
        switch (networkRequest.httpMethod) {
            case HttpMethodEnum.httpGet:
                return this.httpClient.get<any>(networkRequest.url, { responseType: networkRequest.responseType })
            case HttpMethodEnum.httpPost:
                return this.httpClient.post<any>(networkRequest.url, networkRequest.jsonBody)
            case HttpMethodEnum.httpPut:
                return this.httpClient.put<any>(networkRequest.url, networkRequest.jsonBody)
            case HttpMethodEnum.httpDelete:
                return this.httpClient.delete<any>(networkRequest.url)
        }
    }
    callApi(networkRequest: NetworkRequest): Observable<any> {
        return this.getRequest(networkRequest).pipe(
            retryWhen((errors) => {
                return errors.pipe(
                    delay(networkRequest.retryTime),
                    mergeMap((error, index) => {
                        if (index === networkRequest.retryNumber) {
                            return throwError(error)
                        } else {
                            return of(error)
                        }
                    })
                )
            }),
            shareReplay()
        )
    }
}
