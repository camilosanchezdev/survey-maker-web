import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { BaseApi } from 'src/app/core/classes/base-api.class'
import { NetworkRequest } from 'src/app/core/classes/network-request.class'
import { HttpMethodEnum } from 'src/app/core/enums/http-method.enum'
import { NetworkService } from 'src/app/core/services/network.service'
import { environment } from 'src/environments/environment'
import { SurveyModel } from '../models/survey.model'

@Injectable({ providedIn: 'root' })
export class SurveyApi extends BaseApi<SurveyModel> {
    constructor(protected networkService: NetworkService) {
        super(networkService)
        this.apiEndpoint = 'surveys'
    }
    createAsDraft(payload: any): Observable<SurveyModel> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}/draft`, HttpMethodEnum.httpPost, payload))
    }
    markAsActive(surveyId: number): Observable<SurveyModel> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}/${surveyId}/active`, HttpMethodEnum.httpPut))
    }
    markAsCompleted(surveyId: number): Observable<SurveyModel> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}/${surveyId}/completed`, HttpMethodEnum.httpPut))
    }
    filterByStatus(statusId: number): Observable<SurveyModel[]> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}?statusId=${statusId}`, HttpMethodEnum.httpGet))
    }
    getByLink(link: string): Observable<SurveyModel> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}/${link}/link`, HttpMethodEnum.httpGet))
    }
    editAsDraft(surveyId: number, payload: any): Observable<SurveyModel> {
        return this.networkService.callApi(new NetworkRequest(`${environment.apiUrl}/${this.apiEndpoint}/${surveyId}/draft`, HttpMethodEnum.httpPut, payload))
    }
}
