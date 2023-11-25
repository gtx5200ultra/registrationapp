import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FirstStepComponent } from './registration-form/first-step/first-step.component';
import { SecondStepComponent } from './registration-form/second-step/second-step.component';
import { SecondStepGuard } from './registration-form/form-guard.service';

const routes: Routes = [
  { path: '', redirectTo: 'second', pathMatch: 'full' },
  { path: "first", component: FirstStepComponent },
  { path: "second", component: SecondStepComponent, canActivate: [SecondStepGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }