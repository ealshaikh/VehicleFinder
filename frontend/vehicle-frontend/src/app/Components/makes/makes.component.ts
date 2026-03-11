import { Component, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { Make } from 'src/app/interfaces/make';
import { Subject, debounceTime, distinctUntilChanged, switchMap, of } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

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
    this.searchSubject
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        switchMap(query => {
          if (query.length < 2) {
            return of([]);
          }
          return this.vehicleService.getMakes(query, 1, 20);
        }),
        takeUntil(this.destroy$)
      )
      .subscribe({
        next: (makes) => {
          this.makes = [...makes];
          console.log('Suggestions updated:', this.makes);
        },
        error: (err) => {
          console.error(err);
          this.makes = [];
        }
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  searchMakes(event: any) {
    const query = event.query || '';
    this.searchSubject.next(query);
  }

  onMakeSelect() {
    this.makeSelected.emit(this.selectedMake);
  }

}