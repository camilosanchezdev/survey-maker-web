import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { ReportApi } from '../api/report.api'
import { SurveyApi } from '../api/survey.api'
import { UserApi } from '../api/user.api'
import { KpiModel } from '../models/kpi.model'
import { ReportModel } from '../models/report.model'
import { SurveyModel } from '../models/survey.model'
import { ChangePasswordRequest } from '../requests/change-password.request'
import { EditProfileRequest } from '../requests/edit-profile.request'
import { NewSurveyRequest } from '../requests/new-survey.request'

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private surveyApi: SurveyApi, private reportApi: ReportApi, private userApi: UserApi) {}

    getAllSurveys(): Observable<SurveyModel[]> {
        return this.surveyApi.all()
    }
    getSurveysByStatus(surveyStatusId: number): Observable<SurveyModel[]> {
        return this.surveyApi.filterByStatus(surveyStatusId)
    }
    getSurvey(surveyId: number): Observable<SurveyModel> {
        return this.surveyApi.get(surveyId)
    }
    createSurvey(request: NewSurveyRequest): Observable<SurveyModel> {
        return this.surveyApi.create(request)
    }
    createSurveyAsDraft(request: NewSurveyRequest): Observable<SurveyModel> {
        return this.surveyApi.createAsDraft(request)
    }
    markSurveyAsActive(surveyId: number): Observable<SurveyModel> {
        return this.surveyApi.markAsActive(surveyId)
    }
    markSurveyAsCompleted(surveyId: number): Observable<SurveyModel> {
        return this.surveyApi.markAsCompleted(surveyId)
    }
    editSurvey(surveyId: number, request: NewSurveyRequest): Observable<SurveyModel> {
        return this.surveyApi.edit(surveyId, request)
    }
    editSurveyAsDraft(surveyId: number, request: NewSurveyRequest): Observable<SurveyModel> {
        return this.surveyApi.editAsDraft(surveyId, request)
    }
    downloadReport(surveyId: number): Observable<any> {
        return this.reportApi.downloadReport(surveyId)
    }
    getStatistics(surveyId: number): Observable<ReportModel> {
        return this.reportApi.get(surveyId)
    }
    getKpis(): Observable<KpiModel> {
        return this.reportApi.getKpis()
    }
    editProfile(body: EditProfileRequest): Observable<any> {
        return this.userApi.editProfile(body)
    }
    changePassword(body: ChangePasswordRequest): Observable<any> {
        return this.userApi.changePassword(body)
    }
}
