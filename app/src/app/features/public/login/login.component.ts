import { Component, OnInit } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { MatSnackBar } from '@angular/material/snack-bar'
import { ApiError } from 'src/app/core/classes/api-error'
import { AuthService } from 'src/app/core/services/auth.service'
import { LoadingService } from 'src/app/core/services/loading.service'

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
    formGroup: FormGroup
    constructor(private fb: FormBuilder, private authService: AuthService, private loading: LoadingService, private snackBar: MatSnackBar) {}

    ngOnInit(): void {
        this.formGroup = this.fb.group({
            email: [null, [Validators.required, Validators.email]],
            password: [null, Validators.required],
        })
    }
    onSubmit(): void {
        if (this.formGroup.valid) {
            this.loading.show()
            this.authService.login(this.formGroup.value).subscribe({
                error: (error: ApiError) => {
                    this.loading.hide()
                    this.snackBar.open(error.title, error.detail, { duration: 5000 })
                },
                next: () => {
                    this.loading.hide()
                },
            })
        }
    }
}
