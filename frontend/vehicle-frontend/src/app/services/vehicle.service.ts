import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { ApiResponse } from '../interfaces/ApiResponse';
import { Make } from '../interfaces/make';
import { VehicleType } from '../interfaces/vehicle';
import { Model } from '../interfaces/model';

@Injectable({
  providedIn: 'root',
})
export class VehicleService {
  private baseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) {}

  getMakes(search: string = '', page = 1, pageSize = 50): Observable<Make[]> {
    const params = search
      ? `?search=${encodeURIComponent(search)}&page=${page}&pageSize=${pageSize}`
      : `?page=${page}&pageSize=${pageSize}`;
    return this.http
      .get<{
        count: number;
        message: string;
        makes: Make[];
      }>(`${this.baseUrl}/makes${params}`)
      .pipe(map((response) => response.makes));
  }

  getVehicleTypes(
    makeId: number,
    page = 1,
    pageSize = 100,
  ): Observable<VehicleType[]> {
    return this.http.get<VehicleType[]>(
      `${this.baseUrl}/types?makeId=${makeId}&page=${page}&pageSize=${pageSize}`,
    );
  }

  getModels(
    makeId: number,
    modelYear: number,
    page = 1,
    pageSize = 100,
  ): Observable<Model[]> {
    return this.http.get<Model[]>(
      `${this.baseUrl}/models?makeId=${makeId}&modelYear=${modelYear}&page=${page}&pageSize=${pageSize}`,
    );
  }
}
