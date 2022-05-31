import { ComponentFixture, TestBed } from '@angular/core/testing'

import { UserSurveysNewComponent } from './user-surveys-new.component'

describe('UserSurveysNewComponent', () => {
    let component: UserSurveysNewComponent
    let fixture: ComponentFixture<UserSurveysNewComponent>

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [UserSurveysNewComponent],
        }).compileComponents()
    })

    beforeEach(() => {
        fixture = TestBed.createComponent(UserSurveysNewComponent)
        component = fixture.componentInstance
        fixture.detectChanges()
    })

    it('should create', () => {
        expect(component).toBeTruthy()
    })
})
