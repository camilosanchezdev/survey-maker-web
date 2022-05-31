import { environment } from 'src/environments/environment'
import { Injectable } from '@angular/core'
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HTTP_INTERCEPTORS } from '@angular/common/http'
import { Observable } from 'rxjs'

import { switchMap } from 'rxjs/operators'
import { AuthService } from '../services/auth.service'

@Injectable()
export class TokenInterceptorRequest implements HttpInterceptor {
    constructor(private authService: AuthService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.isExceptionUrl(request.url)) {
            return next.handle(request)
        }
        return this.authService.getCurrentToken().pipe(
            switchMap((token) => {
                request = request.clone({
                    setHeaders: {
                        Authorization: `Bearer ${token}`,
                    },
                })
                return next.handle(request)
            })
        )
    }

    private isExceptionUrl(url: string): boolean {
        let exist = false
        // EXCEPTION.forEach((exc) => {
        // 	if (url.includes(exc)) {
        // 		exist = true
        // 	}
        // })
        return exist
    }
}

export let tokenInterceptorProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptorRequest,
    multi: true,
}
