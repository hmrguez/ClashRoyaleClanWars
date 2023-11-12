import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FirstQueryComponent } from './first-query.component';

describe('FirstQueryComponent', () => {
  let component: FirstQueryComponent;
  let fixture: ComponentFixture<FirstQueryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FirstQueryComponent]
    });
    fixture = TestBed.createComponent(FirstQueryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
