import { TestBed } from '@angular/core/testing';

import { BattlesService } from './battles.service';

describe('BattlesService', () => {
  let service: BattlesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BattlesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
