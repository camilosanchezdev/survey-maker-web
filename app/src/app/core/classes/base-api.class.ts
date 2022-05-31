import { Observable } from 'rxjs'
import { map, shareReplay } from 'rxjs/operators'
import { environment } from 'src/environments/environment'
import { HttpMethodEnum } from '../enums/http-method.enum'
import { NetworkService } from '../services/network.service'
import { NetworkRequest } from './network-request.class'

export abstract class BaseApi<T> {
    protected apiEndpoint: string = ''
    protected networkService: NetworkService

    constructor(networkService: NetworkService) {
        this.networkService = networkService
    }

    public all(): Observable<T[]> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}`, HttpMethodEnum.httpGet)).pipe(
            map((response: any) => response.data ?? response),
            shareReplay()
        )
    }

    public get(id: number): Observable<T> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}/${id}`, HttpMethodEnum.httpGet)).pipe(
            map((response: any) => response.data ?? response),
            shareReplay()
        )
    }
    public create(payload: any): Observable<T> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}`, HttpMethodEnum.httpPost, payload))
    }
    public edit(id: number, payload: any): Observable<T> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}/${id}`, HttpMethodEnum.httpPut, payload))
    }
}
