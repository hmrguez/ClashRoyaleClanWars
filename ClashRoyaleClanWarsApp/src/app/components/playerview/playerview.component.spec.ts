import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerviewComponent } from './playerview.component';

describe('PlayerviewComponent', () => {
  let component: PlayerviewComponent;
  let fixture: ComponentFixture<PlayerviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PlayerviewComponent]
    });
    fixture = TestBed.createComponent(PlayerviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
