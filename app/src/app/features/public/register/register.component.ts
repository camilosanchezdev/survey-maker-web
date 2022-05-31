import { Component, OnInit } from '@angular/core'
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms'
import { MatSnackBar } from '@angular/material/snack-bar'
import { AuthService } from 'src/app/core/services/auth.service'
import { LoadingService } from 'src/app/core/services/loading.service'

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
    formGroup: FormGroup
    submitted: boolean = false
    constructor(private fb: FormBuilder, private authService: AuthService, private loading: LoadingService, private snackBar: MatSnackBar) {}

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
    checkEmails: ValidatorFn = (group: AbstractControl): ValidationErrors | null => {
        let pass = group.get('email').value
        let confirmPass = group.get('repeatEmail').value
        return pass === confirmPass ? null : { noMatch: true }
    }
    onSubmit(): void {
        this.submitted = true
        if (this.formGroup.valid) {
            this.loading.show()
            this.authService.register(this.createRequest()).subscribe({
                error: (error: any) => {
                    this.loading.hide()
                    this.snackBar.open(error.title, error.detail, { duration: 5000 })
                },
                next: () => {
                    this.loading.hide()
                },
            })
        }
    }
    createRequest() {
        return {
            name: this.formGroup.get('name').value,
            email: this.formGroup.get('emailGroup.email').value,
            password: this.formGroup.get('passwordGroup.password').value,
        }
    }
}
