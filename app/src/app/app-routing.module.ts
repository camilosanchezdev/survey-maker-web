import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { AppComponent } from './app.component'
import { AuthGuard } from './core/guards/auth.guard'

const routes: Routes = [
    {
        path: '',
        component: AppComponent,
        children: [
            {
                path: 'main',
                loadChildren: () => import('./features/main/main.module').then((m) => m.MainModule),
                canActivate: [AuthGuard],
            },
            {
                path: '',
                loadChildren: () => import('./features/public/public.module').then((m) => m.PublicModule),
            },
        ],
    },
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
