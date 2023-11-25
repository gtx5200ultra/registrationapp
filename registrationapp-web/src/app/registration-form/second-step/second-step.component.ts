import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { Country } from 'src/models/country';
import { CountryRegion } from 'src/models/countryregion';
import { ApiCountryService } from 'src/services/api-country.service';
import { ApiCountryRegionService } from 'src/services/api-countryregion.service';

@Component({
  selector: 'registration-second-step',
  templateUrl: 'second-step.component.html'
})
export class SecondStepComponent implements OnInit, OnDestroy {

  private componentDestroyed$: Subject<boolean> = new Subject()
  private isSubmitted = false;
  locationForm = this.fb.group({
    countryId: [],
    provinceId: []
  });

  countries: Country[] = [];
  provinces: Country[] = [];

  constructor(
    private readonly fb: FormBuilder,
    private readonly apiCountryService: ApiCountryService,
    private readonly apiCountryRegionService: ApiCountryRegionService) { }

  ngOnInit() {
    console.log('a');
    this.apiCountryService.getCountries()
      .pipe(takeUntil(this.componentDestroyed$))
      .subscribe((response: Country[]) => {
        this.countries = response;
      });
  }

  onCountryChange(e: any) {
    this.apiCountryRegionService.getProvinces(this.locationForm.value?.countryId || 0)
      .pipe(takeUntil(this.componentDestroyed$))
      .subscribe((response: CountryRegion[]) => {
        this.provinces = response;
        this.locationForm.patchValue({ provinceId: null });
      });
  }

  onSubmit() {
    this.isSubmitted = true;
    if (this.locationForm.valid) {

    }
    console.warn('Done');
  }

  ngOnDestroy() {
    this.componentDestroyed$.next(true);
    this.componentDestroyed$.complete();
  }
}
