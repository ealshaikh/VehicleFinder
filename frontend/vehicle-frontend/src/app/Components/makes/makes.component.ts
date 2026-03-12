import {
  Component,
  OnInit,
  OnDestroy,
  Output,
  EventEmitter,
} from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { Make } from 'src/app/interfaces/make';
import {
  Subject,
  debounceTime,
  distinctUntilChanged,
  switchMap,
  of,
  takeUntil,
} from 'rxjs';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-makes',
  templateUrl: './makes.component.html',
  styleUrls: ['./makes.component.css'],
})
export class MakesComponent implements OnInit, OnDestroy {
  makeCtrl = new FormControl('');
  makes: Make[] = [];
  selectedMake: Make | null = null;
  @Output() makeSelected = new EventEmitter<Make | null>();
  private destroy$ = new Subject<void>();

  constructor(private vehicleService: VehicleService) {}

  ngOnInit(): void {
    this.makeCtrl.valueChanges
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        switchMap((query) =>
          !query || query.length < 2
            ? of([])
            : this.vehicleService.getMakes(query, 1, 100),
        ),
        takeUntil(this.destroy$),
      )
      .subscribe({
        next: (makes) => (this.makes = [...makes]),
        error: () => (this.makes = []),
      });
  }

 onMakeSelect(selectedName: string) {
  this.selectedMake = this.makes.find(m => m.makeName === selectedName) || null;
  this.makeSelected.emit(this.selectedMake);
}

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
