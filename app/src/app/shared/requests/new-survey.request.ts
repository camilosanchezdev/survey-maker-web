import { QuestionModel } from '../models/question.model'

export interface NewSurveyRequest {
    title: string
    description: string
    endsAt: Date
    questions: QuestionModel[]
    surveyTags: number[]
}

export interface AnswerModel {
    id: number
    name: string
}
