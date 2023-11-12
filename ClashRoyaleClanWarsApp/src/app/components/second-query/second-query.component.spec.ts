import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecondQueryComponent } from './second-query.component';

describe('SecondQueryComponent', () => {
  let component: SecondQueryComponent;
  let fixture: ComponentFixture<SecondQueryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SecondQueryComponent]
    });
    fixture = TestBed.createComponent(SecondQueryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
