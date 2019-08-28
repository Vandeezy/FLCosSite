import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SportDefaultComponent } from './sport-default.component';

describe('SportDefaultComponent', () => {
  let component: SportDefaultComponent;
  let fixture: ComponentFixture<SportDefaultComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SportDefaultComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SportDefaultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
