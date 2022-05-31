export interface SaveResponseRequest {
    link: string
    answers: Array<{ questionId: number; answerIds: Array<number> }>
}
