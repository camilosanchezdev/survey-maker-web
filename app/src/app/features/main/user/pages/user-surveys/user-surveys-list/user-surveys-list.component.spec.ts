import { ComponentFixture, TestBed } from '@angular/core/testing'

import { UserSurveysListComponent } from './user-surveys-list.component'

describe('UserSurveysListComponent', () => {
    let component: UserSurveysListComponent
    let fixture: ComponentFixture<UserSurveysListComponent>

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [UserSurveysListComponent],
        }).compileComponents()
    })

    beforeEach(() => {
        fixture = TestBed.createComponent(UserSurveysListComponent)
        component = fixture.componentInstance
        fixture.detectChanges()
    })

    it('should create', () => {
        expect(component).toBeTruthy()
    })
})
