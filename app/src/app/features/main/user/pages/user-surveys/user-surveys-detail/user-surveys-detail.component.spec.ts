import { ComponentFixture, TestBed } from '@angular/core/testing'

import { UserSurveysDetailComponent } from './user-surveys-detail.component'

describe('UserSurveysDetailComponent', () => {
    let component: UserSurveysDetailComponent
    let fixture: ComponentFixture<UserSurveysDetailComponent>

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [UserSurveysDetailComponent],
        }).compileComponents()
    })

    beforeEach(() => {
        fixture = TestBed.createComponent(UserSurveysDetailComponent)
        component = fixture.componentInstance
        fixture.detectChanges()
    })

    it('should create', () => {
        expect(component).toBeTruthy()
    })
})
