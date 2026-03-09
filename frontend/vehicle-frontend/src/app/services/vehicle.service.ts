import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Model } from '../interfaces/model';
import { VehicleType } from '../interfaces/vehicle';
import { Make } from '../interfaces/make';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  private baseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) { }

  GetMakes(page = 1, pageSize = 100): Observable<Make[]> {
    return this.http.get<Make[]>(`${this.baseUrl}/makes?page=${page}&pageSize=${pageSize}`);
  }

  GetVehicle(make: number, page = 1, pageSize = 100): Observable<VehicleType[]> {
    return this.http.get<VehicleType[]>(`${this.baseUrl}?make=${make}&page=${page}&pageSize=${pageSize}`);
  }

  GetModels(make: number, modelYear: number, page = 1, pageSize = 100): Observable<Model[]> {
    return this.http.get<Model[]>(`${this.baseUrl}/models?make=${make}&modelYear=${modelYear}&page=${page}&pageSize=${pageSize}`);
  }
}
