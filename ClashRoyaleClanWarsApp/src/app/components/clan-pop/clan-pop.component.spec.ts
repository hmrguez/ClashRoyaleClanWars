import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClanPopComponent } from './clan-pop.component';

describe('ClanPopComponent', () => {
  let component: ClanPopComponent;
  let fixture: ComponentFixture<ClanPopComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClanPopComponent]
    });
    fixture = TestBed.createComponent(ClanPopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
