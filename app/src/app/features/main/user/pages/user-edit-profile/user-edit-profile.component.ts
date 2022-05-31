import { Component, OnDestroy, OnInit } from '@angular/core'
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms'
import { MatSnackBar } from '@angular/material/snack-bar'
import { Router } from '@angular/router'
import { Subscription } from 'rxjs'
import { LoadingService } from 'src/app/core/services/loading.service'
import { UserSection } from 'src/app/shared/enums/user-section.enum'
import { ProfileModel } from 'src/app/shared/models/profile.model'
import { EditProfileRequest } from 'src/app/shared/requests/edit-profile.request'
import { UserStateService } from 'src/app/shared/services/user-state.service'
import { UserService } from 'src/app/shared/services/user.service'

@Component({
    selector: 'app-user-edit-profile',
    templateUrl: './user-edit-profile.component.html',
    styleUrls: ['./user-edit-profile.component.scss'],
})
export class UserEditProfileComponent implements OnInit, OnDestroy {
    private subscriptions = new Subscription()
    submitted: boolean = false
    formGroup: FormGroup
    SECTION = UserSection
    profile: ProfileModel
    constructor(
        private fb: FormBuilder,
        private userStateService: UserStateService,
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
            name: [null, Validators.required],
            emailGroup: this.fb.group(
                {
                    email: [null, [Validators.required, Validators.email]],
                    repeatEmail: [null, [Validators.required, Validators.email]],
                },
                { validators: this.checkEmails }
            ),
        })
        this.loading.show()
        this.subscriptions.add(
            this.userStateService.getProfile().subscribe({
                error: (error: any) => {
                    this.loading.hide()
                    this.snackBar.open(error.title, error.detail, { duration: 5000 })
                },
                next: (response) => {
                    this.loading.hide()
                    this.profile = response
                    this.setForm()
                },
            })
        )
    }
    setForm(): void {
        this.formGroup.get('name').setValue(this.profile.name)
        this.formGroup.get('emailGroup.email').setValue(this.profile.email)
    }
    onSubmit(): void {
        this.submitted = true
        if (this.formGroup.valid) {
            this.loading.show()
            this.subscriptions.add(
                this.userService.editProfile(this.createRequest()).subscribe({
                    error: (error: any) => {
                        this.loading.hide()
                        this.snackBar.open(error.title, error.detail, { duration: 5000 })
                    },
                    next: (response: ProfileModel) => {
                        this.loading.hide()
                        this.userStateService.setProfile(response)
                        this.snackBar.open('Profile updated successfully', '', { duration: 1000 })
                        this.router.navigate(['/main/profile'])
                    },
                })
            )
        }
    }
    createRequest(): EditProfileRequest {
        return {
            name: this.formGroup.get('name').value,
            email: this.formGroup.get('emailGroup.email').value,
        }
    }
    checkEmails: ValidatorFn = (group: AbstractControl): ValidationErrors | null => {
        let pass = group.get('email').value
        let confirmPass = group.get('repeatEmail').value
        return pass === confirmPass ? null : { noMatch: true }
    }
}
