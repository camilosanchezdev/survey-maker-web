import { QuestionModel } from './question.model'

export interface SurveyModel {
    createdAt: Date
    description: string
    disabledAt?: Date
    endsAt: Date
    id: number
    link: string
    surveyStatusId: number
    surveyStatusName: string
    surveyTags: Array<string>
    userId: number
    title: string
    questions: Array<QuestionModel>
    hasResponses: boolean
}
