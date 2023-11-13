import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QueryViewerComponent } from './query-viewer.component';

describe('QueryViewerComponent', () => {
  let component: QueryViewerComponent;
  let fixture: ComponentFixture<QueryViewerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [QueryViewerComponent]
    });
    fixture = TestBed.createComponent(QueryViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
