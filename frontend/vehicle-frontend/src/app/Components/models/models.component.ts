import { Component, Input } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { Model } from 'src/app/interfaces/model';
import { Make } from 'src/app/interfaces/make';

@Component({
  selector: 'app-models',
  templateUrl: './models.component.html',
  styleUrls: ['./models.component.css']
})
export class ModelsComponent {
    @Input() selectedMake: Make | null = null;
  
  year: number | null = null;
  currentYear = new Date().getFullYear();
  selectedType: string | null = null;   
  models: Model[] = [];

  constructor(private vehicleService: VehicleService) {}

onFind() {
  if (!this.selectedMake || !this.year) return;

  this.vehicleService.getModels(this.selectedMake.makeId, this.year).subscribe({
    next: (res) => {
      console.log('Models fetched:', res);
      this.models = res;
    },
    error: () => this.models = []
  });
}
}