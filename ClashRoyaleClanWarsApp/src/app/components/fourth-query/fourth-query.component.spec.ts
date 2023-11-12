import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FourthQueryComponent } from './fourth-query.component';

describe('FourthQueryComponent', () => {
  let component: FourthQueryComponent;
  let fixture: ComponentFixture<FourthQueryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FourthQueryComponent]
    });
    fixture = TestBed.createComponent(FourthQueryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
