import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiProvinceService {

  constructor(private http: HttpClient) { }

  getProvinces(id: number): Observable<any> {
    return this.http.get<any>(`api/provinces?countryId=${id}`);
  }
}