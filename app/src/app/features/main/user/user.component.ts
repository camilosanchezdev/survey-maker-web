import { load } from '@amcharts/amcharts5/.internal/core/util/Net'
import { Component, OnInit } from '@angular/core'
import { BaseInitModule } from 'src/app/core/classes/base-init-module.class'
import { InitService } from 'src/app/core/services/init.service'
import { LoadingService } from 'src/app/core/services/loading.service'

@Component({
    selector: 'app-user',
    templateUrl: './user.component.html',
    styleUrls: ['./user.component.scss'],
})
export class UserComponent extends BaseInitModule {
    constructor(initService: InitService, loading: LoadingService) {
        super(initService, loading)
    }
    onDestroy() {}
    moduleName(): string {
        return 'UserModule'
    }
}
