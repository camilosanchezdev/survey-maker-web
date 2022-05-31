import { Pipe, PipeTransform } from '@angular/core'

@Pipe({
    name: 'surveyStatus',
})
export class SurveyStatusPipe implements PipeTransform {
    transform(status: number): any {
        switch (status) {
            case 1:
                return 'Active'
            case 2:
                return 'Draft'
            case 3:
                return 'Completed'
        }
    }
}
