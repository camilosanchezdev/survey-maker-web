import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { BaseApi } from 'src/app/core/classes/base-api.class'
import { NetworkRequest } from 'src/app/core/classes/network-request.class'
import { HttpMethodEnum } from 'src/app/core/enums/http-method.enum'
import { NetworkService } from 'src/app/core/services/network.service'
import { environment } from 'src/environments/environment'
import { KpiModel } from '../models/kpi.model'
import { ReportModel } from '../models/report.model'

@Injectable({ providedIn: 'root' })
export class ReportApi extends BaseApi<ReportModel> {
    constructor(protected networkService: NetworkService) {
        super(networkService)
        this.apiEndpoint = 'reports'
    }
    downloadReport(surveyId: number): Observable<any> {
        return this.networkService.callApi(
            new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}/${surveyId}/report`, HttpMethodEnum.httpGet, null, null, 1500, 'blob')
        )
    }
    getKpis(): Observable<KpiModel> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}/kpi`, HttpMethodEnum.httpGet))
    }
}
