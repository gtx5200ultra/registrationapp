import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing';
import { ReactiveFormsModule } from '@angular/forms';

import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { FirstStepComponent } from './registration-form/first-step/first-step.component';
import { SecondStepComponent } from './registration-form/second-step/second-step.component';
import { ApiCountryService } from 'src/services/api-country.service';
import { ApiResponseInterceptor } from 'src/services/api-response.interceptor';
import { ApiCountryRegionService } from 'src/services/api-countryregion.service';
import { ApiUserService } from 'src/services/api-user.service';

@NgModule({
  declarations: [
    AppComponent,
    FirstStepComponent,
    SecondStepComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    MatInputModule,
    MatCheckboxModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule
  ],
  providers: [
    ApiCountryService,
    ApiCountryRegionService,
    ApiUserService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiResponseInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
