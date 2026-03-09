import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Make } from '../interfaces/make';
import { VehicleType } from '../interfaces/vehicle';
import { Model } from '../interfaces/model';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  private baseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) {}

  getMakes(page = 1, pageSize = 100): Observable<Make[]> {
    return this.http.get<Make[]>(`${this.baseUrl}/makes?page=${page}&pageSize=${pageSize}`);
  }

  getVehicleTypes(makeId: number, page = 1, pageSize = 100): Observable<VehicleType[]> {
    return this.http.get<VehicleType[]>(`${this.baseUrl}/types?makeId=${makeId}&page=${page}&pageSize=${pageSize}`);
  }

  getModels(makeId: number, modelYear: number, page = 1, pageSize = 100): Observable<Model[]> {
    return this.http.get<Model[]>(`${this.baseUrl}/models?makeId=${makeId}&modelYear=${modelYear}&page=${page}&pageSize=${pageSize}`);
  }
}