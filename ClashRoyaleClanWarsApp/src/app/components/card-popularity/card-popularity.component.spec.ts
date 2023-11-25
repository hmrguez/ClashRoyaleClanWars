import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardPopularityComponent } from './card-popularity.component';

describe('CardPopularityComponent', () => {
  let component: CardPopularityComponent;
  let fixture: ComponentFixture<CardPopularityComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CardPopularityComponent]
    });
    fixture = TestBed.createComponent(CardPopularityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
