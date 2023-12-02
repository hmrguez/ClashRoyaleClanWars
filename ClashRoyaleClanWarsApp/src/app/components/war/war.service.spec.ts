import { TestBed } from '@angular/core/testing';

import { WarService } from './war.service';

describe('WarService', () => {
  let service: WarService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WarService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
