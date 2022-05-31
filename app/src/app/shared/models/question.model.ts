import { AnswerModel } from './answer.model'

export interface QuestionModel {
    id: number
    name: string
    multiple: boolean
    answers: Array<AnswerModel>
}
