import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
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
import { ApiCountryRegionService } from 'src/services/api-countryregion.service';
import { ApiUserService } from 'src/services/api-user.service';
import { ToastrModule } from 'ngx-toastr';
import { GlobalErrorHandler } from 'src/services/error-handler';

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
    MatSelectModule,
    ToastrModule.forRoot()
  ],
  providers: [
    ApiCountryService,
    ApiCountryRegionService,
    ApiUserService,
    {
      provide: ErrorHandler,
      useClass: GlobalErrorHandler
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
