import { Injectable } from '@angular/core'
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router'

@Injectable({
    providedIn: 'root',
})
export class PublicGuard implements CanActivate {
    constructor(private router: Router) {}
    canActivate(route: ActivatedRouteSnapshot): boolean {
        // TODO: ENABLE IN PRODUCTION

        // const surveyLink = route.params.id
        // const surveysAnswered = localStorage.getItem('surveymakeranswers')
        // if (surveysAnswered) {
        //     const list = <string[]>JSON.parse(surveysAnswered)
        //     if (!list.find((x) => x === surveyLink)) {
        //         return true
        //     } else {
        //         this.router.navigate([''])
        //         return false
        //     }
        // }
        return true
    }
}
