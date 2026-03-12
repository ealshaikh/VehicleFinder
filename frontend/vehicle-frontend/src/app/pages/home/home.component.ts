import { Component } from '@angular/core';
import { Make } from 'src/app/interfaces/make';
import { Model } from 'src/app/interfaces/model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

 selectedMake: Make | null = null;
  models: Model[] = []; // ← هنا نخزن الموديلات

  onMakeSelected(make: Make | null) {
    this.selectedMake = make;
    this.models = []; // Reset previous results
  }

  onModelsFetched(models: Model[]) {
    this.models = models;
  }
}