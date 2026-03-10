import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { environment } from '../environments/environment';

import { ApiResponse } from '../interfaces/ApiResponse';
import { VehicleType } from '../interfaces/vehicle';
import { Make } from '../interfaces/make';
import { Model } from '../interfaces/model';
@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  private baseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) {}

  getMakes(page = 1, pageSize = 100): Observable<Make[]> {
    return this.http
      .get<ApiResponse<Make>>(`${this.baseUrl}/makes?page=${page}&pageSize=${pageSize}`)
      .pipe(
        map(response => response.Results)
      );
  }

  getVehicleTypes(makeId: number, page = 1, pageSize = 100): Observable<VehicleType[]> {
    return this.http
      .get<ApiResponse<VehicleType>>(`${this.baseUrl}/types?makeId=${makeId}&page=${page}&pageSize=${pageSize}`)
      .pipe(
        map(response => response.Results)
      );
  }

  getModels(makeId: number, modelYear: number, page = 1, pageSize = 100): Observable<Model[]> {
    return this.http
      .get<ApiResponse<Model>>(`${this.baseUrl}/models?makeId=${makeId}&modelYear=${modelYear}&page=${page}&pageSize=${pageSize}`)
      .pipe(
        map(response => response.Results)
      );
  }

}