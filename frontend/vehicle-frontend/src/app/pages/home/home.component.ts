import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { Make } from 'src/app/interfaces/make';
import { VehicleType } from 'src/app/interfaces/vehicle';
import { Model } from 'src/app/interfaces/model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  selectedMake: Make | null = null;
  selectedYear: number | null = null;
  maxYear: number = new Date().getFullYear() + 1;
  makes: Make[] = [];
  vehicleTypes: VehicleType[] = [];
  models: Model[] = [];
  hasSearched = false;
  loading = false;

  constructor(private vehicleService: VehicleService) {}

  searchMakes(event: any) {
    const query = event.query;
    if (query.length >= 2) {
      this.vehicleService.getMakes(query).subscribe({
        next: (makes) => {
          this.makes = makes;
        },
        error: (error) => {
          console.error('Error fetching makes:', error);
          this.makes = [];
        }
      });
    } else {
      this.makes = [];
    }
  }

  onMakeSelected(make: Make | null) {
    this.selectedMake = make;
  }

  onSubmit() {
    if (this.selectedMake && this.selectedYear) {
      this.hasSearched = true;
      this.loading = true;
      // this.loadResults();
    }
  }

  // private loadResults() {
  //   // Load vehicle types
  //   this.vehicleService.getVehicleTypes(this.selectedMake!.makeId).subscribe({
  //     next: (types) => {
  //       this.vehicleTypes = types;
  //       this.loadModels();
  //     },
  //     error: (error) => {
  //       console.error('Error fetching vehicle types:', error);
  //       this.vehicleTypes = [];
  //       this.loadModels();
  //     }
  //   });
  // }

}
