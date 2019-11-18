import { TestBed } from '@angular/core/testing';

import { VehicleserviceService } from './vehicleservice.service';

describe('VehicleserviceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VehicleserviceService = TestBed.get(VehicleserviceService);
    expect(service).toBeTruthy();
  });
});
