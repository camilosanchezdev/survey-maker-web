import { Injectable } from '@angular/core'
import { map, Observable, shareReplay } from 'rxjs'
import { BaseApi } from 'src/app/core/classes/base-api.class'
import { NetworkRequest } from 'src/app/core/classes/network-request.class'
import { HttpMethodEnum } from 'src/app/core/enums/http-method.enum'
import { NetworkService } from 'src/app/core/services/network.service'
import { environment } from 'src/environments/environment'
import { LoginModel } from '../models/login.model'
import { ProfileModel } from '../models/profile.model'
import { AuthRequest } from '../requests/auth.request'
import { ChangePasswordRequest } from '../requests/change-password.request'
import { RegisterRequest } from '../requests/register.request'

@Injectable({ providedIn: 'root' })
export class UserApi extends BaseApi<any> {
    constructor(protected networkService: NetworkService) {
        super(networkService)
        this.apiEndpoint = 'users'
    }
    login(body: AuthRequest): Observable<LoginModel> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/auth/login`, HttpMethodEnum.httpPost, body, 0))
    }
    register(body: RegisterRequest): Observable<any> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/auth/register`, HttpMethodEnum.httpPost, body))
    }
    getUser(): Observable<ProfileModel> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}`, HttpMethodEnum.httpGet)).pipe(
            map((response: any) => response.data ?? response),
            shareReplay()
        )
    }
    changePassword(body: ChangePasswordRequest): Observable<any> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}/changepassword`, HttpMethodEnum.httpPut, body))
    }
    editProfile(payload: any): Observable<any> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}`, HttpMethodEnum.httpPut, payload))
    }
}
