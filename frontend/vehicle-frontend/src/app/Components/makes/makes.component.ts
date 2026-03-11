import { Component, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { Make } from 'src/app/interfaces/make';
import { Subject, debounceTime, distinctUntilChanged, switchMap, of, takeUntil } from 'rxjs';

@Component({
  selector: 'app-makes',
  templateUrl: './makes.component.html',
  styleUrls: ['./makes.component.css']
})
export class MakesComponent implements OnInit, OnDestroy {

  makes: Make[] = [];
  selectedMake: Make | null = null;
  @Output() makeSelected = new EventEmitter<Make | null>();
  private searchSubject = new Subject<string>();
  private destroy$ = new Subject<void>();

  constructor(private vehicleService: VehicleService) {}

  ngOnInit(): void {
    this.searchSubject.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap(query => query.length < 2 ? of([]) : this.vehicleService.getMakes(query, 1, 100)),
      takeUntil(this.destroy$)
    ).subscribe({
      next: (makes) => this.makes = [...makes],
      error: () => this.makes = []
    });
  }

  searchMakes(event: any) {
    this.searchSubject.next(event.query || '');
  }

  onMakeSelect() {
    this.makeSelected.emit(this.selectedMake);
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}