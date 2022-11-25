import { TestBed } from '@angular/core/testing';

import { InspectionTypesService } from './inspection-types.service';

describe('InspectionTypesService', () => {
  let service: InspectionTypesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InspectionTypesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
