import { TestBed } from '@angular/core/testing';

import { FirstQueryService } from './first-query.service';

describe('FirstQueryService', () => {
  let service: FirstQueryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FirstQueryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
