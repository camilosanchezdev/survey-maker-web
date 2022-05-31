import { ComponentFixture, TestBed } from '@angular/core/testing'

import { UserSurveysEditComponent } from './user-surveys-edit.component'

describe('UserSurveysEditComponent', () => {
    let component: UserSurveysEditComponent
    let fixture: ComponentFixture<UserSurveysEditComponent>

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [UserSurveysEditComponent],
        }).compileComponents()
    })

    beforeEach(() => {
        fixture = TestBed.createComponent(UserSurveysEditComponent)
        component = fixture.componentInstance
        fixture.detectChanges()
    })

    it('should create', () => {
        expect(component).toBeTruthy()
    })
})
