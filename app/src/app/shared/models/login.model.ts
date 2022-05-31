export interface LoginModel {
    id: number
    token: string
    email: string
    name: string
    expirationDate: Date
    refreshToken: string
    createdAt: Date
}
