import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { HttpClientModule } from '@angular/common/http'
import { SharedModule } from './shared/shared.module'
import { tokenInterceptorProvider } from './core/interceptors/token.interceptor'
import { StateModule } from './core/state/state.module'
import { errorInterceptorProvider } from './core/interceptors/error.interceptor'

@NgModule({
    declarations: [AppComponent],
    imports: [BrowserModule, AppRoutingModule, BrowserAnimationsModule, HttpClientModule, SharedModule, StateModule],
    providers: [tokenInterceptorProvider, errorInterceptorProvider],
    bootstrap: [AppComponent],
})
export class AppModule {}
