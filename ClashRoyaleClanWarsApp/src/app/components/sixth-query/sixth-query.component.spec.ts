import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SixthQueryComponent } from './sixth-query.component';

describe('SixthQueryComponent', () => {
  let component: SixthQueryComponent;
  let fixture: ComponentFixture<SixthQueryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SixthQueryComponent]
    });
    fixture = TestBed.createComponent(SixthQueryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
