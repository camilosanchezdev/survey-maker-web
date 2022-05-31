export interface ReportModel {
    surveyTitle: string
    surveyId: number
    responseQuantity: 6
    questionAnswer: Array<QuestionAnswer>
}
interface QuestionAnswer {
    questionId: number
    questionName: string
    answerQuantity: Array<AnswerQuantity>
}
interface AnswerQuantity {
    answerId: number
    answerName: string
    quantity: number
}
