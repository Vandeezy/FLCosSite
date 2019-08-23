import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SportManagementComponent } from './sport-management.component';

describe('SportManagementComponent', () => {
  let component: SportManagementComponent;
  let fixture: ComponentFixture<SportManagementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SportManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SportManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
