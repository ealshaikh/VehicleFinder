import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { VehicleType } from 'src/app/interfaces/vehicle';
import { Make } from 'src/app/interfaces/make';

@Component({
  selector: 'app-vehicles',
  templateUrl: './vehicles.component.html',
  styleUrls: ['./vehicles.component.css']
})
export class VehiclesComponent implements OnChanges {

  @Input() selectedMake: Make | null = null;

  vehicleTypes: VehicleType[] = [];
  selectedType: VehicleType | null = null;
  notFound = false;

  constructor(private vehicleService: VehicleService) {}

  ngOnChanges(changes: SimpleChanges) {
    if (changes['selectedMake'] && this.selectedMake) {
      this.loadVehicleTypes(this.selectedMake.makeId);
    }
  }

 loadVehicleTypes(makeId: number) {
  this.vehicleService.getVehicleTypes(makeId).subscribe({
    next: (types) => {
      this.vehicleTypes = types || [];
      this.notFound = this.vehicleTypes.length === 0;
    },
    error: () => {
      this.vehicleTypes = [];
      this.notFound = true;
    }
  });
}
}