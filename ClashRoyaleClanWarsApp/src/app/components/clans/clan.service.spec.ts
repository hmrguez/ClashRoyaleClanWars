import { TestBed } from '@angular/core/testing';

import { ClanService } from './clan.service';

describe('ClanService', () => {
  let service: ClanService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClanService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
