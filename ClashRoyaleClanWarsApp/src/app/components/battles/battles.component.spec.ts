import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BattlesComponent } from './battles.component';

describe('BattlesComponent', () => {
  let component: BattlesComponent;
  let fixture: ComponentFixture<BattlesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BattlesComponent]
    });
    fixture = TestBed.createComponent(BattlesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
