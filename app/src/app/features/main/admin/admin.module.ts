import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { AdminComponent } from './admin.component'
import { AdminDashboardComponent } from './pages/admin-dashboard/admin-dashboard.component'
import { AdminSettingsComponent } from './pages/admin-settings/admin-settings.component'
import { AdminUsersComponent } from './pages/admin-users/admin-users.component'
import { AdminInvoicesComponent } from './pages/admin-invoices/admin-invoices.component'
import { AdminSupportComponent } from './pages/admin-support/admin-support.component'
import { AdminProfileComponent } from './pages/admin-profile/admin-profile.component'

@NgModule({
    declarations: [
        AdminComponent,
        AdminDashboardComponent,
        AdminSettingsComponent,
        AdminUsersComponent,
        AdminInvoicesComponent,
        AdminSupportComponent,
        AdminProfileComponent,
    ],
    imports: [CommonModule],
})
export class AdminModule {}
