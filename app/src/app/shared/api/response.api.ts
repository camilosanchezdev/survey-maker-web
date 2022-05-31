import { Injectable } from '@angular/core'
import { BaseApi } from 'src/app/core/classes/base-api.class'
import { NetworkService } from 'src/app/core/services/network.service'

@Injectable({ providedIn: 'root' })
export class ResponseApi extends BaseApi<any> {
    constructor(protected networkService: NetworkService) {
        super(networkService)
        this.apiEndpoint = 'responses'
    }
}
