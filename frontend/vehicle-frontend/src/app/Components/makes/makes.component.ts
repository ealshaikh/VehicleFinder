import { Component, OnInit } from '@angular/core';
import { Make } from 'src/app/interfaces/make';

@Component({
  selector: 'app-makes',
  templateUrl: './makes.component.html',
  styleUrls: ['./makes.component.css']
})
export class MakesComponent implements OnInit {
  makes : Make[] = [];
  
  constructor() { }

  ngOnInit(): void {
  }

}
