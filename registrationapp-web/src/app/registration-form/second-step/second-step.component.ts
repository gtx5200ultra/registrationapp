import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { Country } from 'src/models/country';
import { CountryRegion } from 'src/models/countryregion';
import { ApiCountryService } from 'src/services/api-country.service';
import { ApiCountryRegionService } from 'src/services/api-countryregion.service';
import { RegistrationFormDataService } from '../form-data.service';
import { ApiUserService } from 'src/services/api-user.service';
import { User } from 'src/models/user';

@Component({
  selector: 'registration-second-step',
  templateUrl: 'second-step.component.html'
})
export class SecondStepComponent implements OnInit, OnDestroy {

  private componentDestroyed$: Subject<boolean> = new Subject()
  isSubmitted = false;

  locationForm = this.fb.group({
    countryId: [, {
      validators:
        [
          Validators.required
        ], updateOn: "change"
    }],
    countryRegionId: [{ value: null, disabled: true }, {
      validators:
        [
          Validators.required
        ], updateOn: "change"
    }]
  });

  countries: Country[] = [];
  countryRegions: Country[] = [];

  constructor(
    private readonly fb: FormBuilder,
    private readonly apiCountryService: ApiCountryService,
    private readonly apiCountryRegionService: ApiCountryRegionService,
    private readonly apiUserService: ApiUserService,
    private readonly formDataService: RegistrationFormDataService) { }

  ngOnInit() {
    this.apiCountryService.getCountries()
      .pipe(takeUntil(this.componentDestroyed$))
      .subscribe((response: Country[]) => {
        this.countries = response;
      });
  }

  onCountryChange(e: any) {
    this.apiCountryRegionService.getCountryRegionsByCountry(this.locationForm.value?.countryId || 0)
      .pipe(takeUntil(this.componentDestroyed$))
      .subscribe((response: CountryRegion[]) => {
        this.countryRegions = response;
        this.locationForm.patchValue({ countryRegionId: null });
        this.locationForm.controls['countryRegionId'].enable();
      });
  }

  onSubmit() {
    this.isSubmitted = true;
    if (this.locationForm.valid) {
      console.log(this.formDataService.getFirstStepData());
      console.log(this.locationForm.value);
      let user = { ...this.formDataService.getFirstStepData(), ...this.locationForm.value } as User;

      this.apiUserService.createUser(user)
      .pipe(takeUntil(this.componentDestroyed$))
      .subscribe(() => {
        console.log('done');
      });

      console.log(user);
    }
    console.warn('Done');
  }

  ngOnDestroy() {
    this.componentDestroyed$.next(true);
    this.componentDestroyed$.complete();
  }
}
