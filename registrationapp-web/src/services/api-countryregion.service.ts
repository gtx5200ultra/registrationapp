import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CountryRegion } from 'src/models/countryregion';

@Injectable({
  providedIn: 'root'
})
export class ApiCountryRegionService {

  constructor(private http: HttpClient) { }

  getCountryRegionsByCountry(id: number): Observable<CountryRegion[]> {
    return this.http.get<CountryRegion[]>(`api/countryregions?countryId=${id}`);
  }
}