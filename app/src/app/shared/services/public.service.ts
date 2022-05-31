import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { ResponseApi } from '../api/response.api'
import { SurveyApi } from '../api/survey.api'
import { SurveyModel } from '../models/survey.model'
import { SaveResponseRequest } from '../requests/save-response.request'

@Injectable({ providedIn: 'root' })
export class PublicService {
    constructor(private surveyApi: SurveyApi, private responseApi: ResponseApi) {}

    getSurveyByLink(link: string): Observable<SurveyModel> {
        return this.surveyApi.getByLink(link)
    }
    saveResponse(payload: SaveResponseRequest): Observable<any> {
        return this.responseApi.create(payload)
    }
    surveyAnswered(surveyLink: string): void {
        const surveysAnswered = localStorage.getItem('surveymakeranswers')

        if (surveysAnswered) {
            const list = <string[]>JSON.parse(surveysAnswered)
            if (!list.find((x) => x === surveyLink)) {
                list.push(surveyLink)
                localStorage.setItem('surveymakeranswers', JSON.stringify(list))
            }
        } else {
            const newItem = [surveyLink]
            localStorage.setItem('surveymakeranswers', JSON.stringify(newItem))
        }
    }
}
