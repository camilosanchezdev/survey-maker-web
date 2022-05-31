import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserSurveysStatisticsComponent } from './user-surveys-statistics.component';

describe('UserSurveysStatisticsComponent', () => {
  let component: UserSurveysStatisticsComponent;
  let fixture: ComponentFixture<UserSurveysStatisticsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserSurveysStatisticsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserSurveysStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
