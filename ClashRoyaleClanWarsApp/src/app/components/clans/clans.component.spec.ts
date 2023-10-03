import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClansComponent } from './clans.component';

describe('ClansComponent', () => {
  let component: ClansComponent;
  let fixture: ComponentFixture<ClansComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClansComponent]
    });
    fixture = TestBed.createComponent(ClansComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
