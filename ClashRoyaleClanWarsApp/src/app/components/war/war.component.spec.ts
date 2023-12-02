import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WarComponent } from './war.component';

describe('WarComponent', () => {
  let component: WarComponent;
  let fixture: ComponentFixture<WarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WarComponent]
    });
    fixture = TestBed.createComponent(WarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
