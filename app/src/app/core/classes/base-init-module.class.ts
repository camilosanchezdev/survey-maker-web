import { Injectable, OnDestroy, OnInit } from '@angular/core'
import { Subscription } from 'rxjs'
import { InitService } from '../services/init.service'
import { LoadingService } from '../services/loading.service'

@Injectable()
export abstract class BaseInitModule implements OnInit, OnDestroy {
    private sub: Subscription

    constructor(protected initService: InitService, protected loading: LoadingService) {}
    abstract onDestroy()
    abstract moduleName(): string

    ngOnDestroy(): void {
        this.onDestroy()
    }
    ngOnInit(): void {
        this.loading.show()
        this.initService.startInitModule(this.moduleName())
    }
}
