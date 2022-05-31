import { Component, OnDestroy, OnInit } from '@angular/core'
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms'
import { MatSnackBar } from '@angular/material/snack-bar'
import { Router } from '@angular/router'
import { Subscription } from 'rxjs'
import { LoadingService } from 'src/app/core/services/loading.service'
import { UserSection } from 'src/app/shared/enums/user-section.enum'
import { ChangePasswordRequest } from 'src/app/shared/requests/change-password.request'
import { UserService } from 'src/app/shared/services/user.service'

@Component({
    selector: 'app-user-change-password',
    templateUrl: './user-change-password.component.html',
    styleUrls: ['./user-change-password.component.scss'],
})
export class UserChangePasswordComponent implements OnInit, OnDestroy {
    private subscriptions = new Subscription()
    SECTION = UserSection
    submitted: boolean = false
    formGroup: FormGroup
    constructor(
        private fb: FormBuilder,
        private loading: LoadingService,
        private userService: UserService,
        private router: Router,
        private snackBar: MatSnackBar
    ) {}
    ngOnDestroy(): void {
        this.subscriptions.unsubscribe()
    }

    ngOnInit(): void {
        this.formGroup = this.fb.group({
            currentPassword: [null, Validators.required],
            passwordGroup: this.fb.group(
                {
                    password: [null, Validators.required],
                    repeatPassword: [null, Validators.required],
                },
                { validators: this.checkPasswords }
            ),
        })
    }
    checkPasswords: ValidatorFn = (group: AbstractControl): ValidationErrors | null => {
        let pass = group.get('password').value
        let confirmPass = group.get('repeatPassword').value
        return pass === confirmPass ? null : { noMatch: true }
    }
    onSubmit(): void {
        this.submitted = true
        if (this.formGroup.valid) {
            this.loading.show()
            this.subscriptions.add(
                this.userService.changePassword(this.createRequest()).subscribe({
                    error: (error: any) => {
                        this.loading.hide()
                        this.snackBar.open(error.title, error.detail, { duration: 5000 })
                    },
                    next: (response: any) => {
                        this.loading.hide()
                        this.snackBar.open('Password changed successfully', '', { duration: 1000 })
                        this.router.navigate(['/main/profile'])
                    },
                })
            )
        }
    }
    createRequest(): ChangePasswordRequest {
        return {
            oldPassword: this.formGroup.get('currentPassword').value,
            newPassword: this.formGroup.get('passwordGroup.password').value,
        }
    }
}
