import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignupstudentComponent } from './signupstudent.component';

describe('SignupstudentComponent', () => {
  let component: SignupstudentComponent;
  let fixture: ComponentFixture<SignupstudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignupstudentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SignupstudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
