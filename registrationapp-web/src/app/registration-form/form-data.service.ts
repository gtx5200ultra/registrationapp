import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class RegistrationFormDataService {
  private firstStepData = null;

  getFirstStepData(): any {
    return this.firstStepData;
  }

  setFirstStepData(data: any): void {
    this.firstStepData = data;
  }
}