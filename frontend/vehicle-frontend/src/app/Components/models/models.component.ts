import { Component, Input, Output, EventEmitter } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { Model } from 'src/app/interfaces/model';
import { Make } from 'src/app/interfaces/make';

@Component({
  selector: 'app-models',
  templateUrl: './models.component.html',
  styleUrls: ['./models.component.css'],
})
export class ModelsComponent {
  @Input() selectedMake: Make | null = null;
  @Output() modelsFetched = new EventEmitter<Model[]>();

  year: number | null = null;
  currentYear = new Date().getFullYear();
  models: Model[] = [];
  loadingModels = false;
  constructor(private vehicleService: VehicleService) {}

  onFind() {
    if (!this.selectedMake || !this.year) return;

    this.loadingModels = true;

    this.vehicleService
      .getModels(this.selectedMake.makeId, this.year)
      .subscribe({
        next: (res) => {
          this.models = res;
          this.modelsFetched.emit(res);
          this.loadingModels = false;
        },
        error: () => {
          this.models = [];
          this.modelsFetched.emit([]);
          this.loadingModels = false;
        },
      });
  }
}
