import { Component } from '@angular/core';
import { Make } from 'src/app/interfaces/make';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  selectedMake: Make | null = null;

  // when the user selects a new make, update the selectedMake property
  onMakeSelected(make: Make | null) {
    this.selectedMake = make;
    console.log('Selected make in HomeComponent:', make);
  }
}