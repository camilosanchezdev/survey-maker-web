import { NgModule } from '@angular/core'
import { StoreModule } from '@ngrx/store'
import { authReducer } from './reducers/auth.reducer'
import { EffectsModule } from '@ngrx/effects'
import { AuthEffects } from './effects/auth.effects'
import { StoreDevtoolsModule } from '@ngrx/store-devtools'

@NgModule({
    declarations: [],
    imports: [
        StoreModule.forRoot({
            auth: authReducer,
        }),
        EffectsModule.forRoot([AuthEffects]),
        StoreDevtoolsModule.instrument({
            maxAge: 25,
        }),
    ],
    providers: [],
})
export class StateModule {}
