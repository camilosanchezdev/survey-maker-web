import { Component, Inject, OnInit } from '@angular/core'
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog'
import { QuestionModel } from 'src/app/shared/models/question.model'

@Component({
    selector: 'ui-add-question',
    templateUrl: './ui-add-question.component.html',
    styleUrls: ['./ui-add-question.component.scss'],
})
export class UiAddQuestionComponent implements OnInit {
    formGroup: FormGroup
    submitted: boolean = false
    constructor(private fb: FormBuilder, public dialogRef: MatDialogRef<UiAddQuestionComponent>, @Inject(MAT_DIALOG_DATA) public data: QuestionModel) {}
    get answers() {
        return this.formGroup.get('answers') as FormArray
    }
    ngOnInit(): void {
        this.formGroup = this.fb.group({
            question: ['', Validators.required],
            multiple: [false, Validators.required],
            answers: this.fb.array([]),
        })
        if (this.data) {
            this.formGroup.patchValue({
                question: this.data.name,
                multiple: this.data.multiple,
            })

            this.data.answers.forEach((answer) => {
                this.addAnswer(answer.name)
            })
        } else {
            this.addAnswer()
            this.addAnswer()
        }
    }
    clearControl(index: number): void {
        this.answers.controls[index].reset()
    }
    addAnswer(answer: string = ''): void {
        const newAnswer = new FormControl(answer, Validators.required)
        this.answers.push(newAnswer)
    }
    submit(): void {
        this.submitted = true

        if (this.formGroup.valid) {
            const newQuestion: QuestionModel = {
                id: this.data?.id ? this.data.id : 0,
                name: this.formGroup.get('question').value,
                multiple: this.formGroup.get('multiple').value,
                answers: this.answers.controls.map((x) => ({ id: 0, name: x.value })),
            }
            this.dialogRef.close(newQuestion)
        }
    }
}
