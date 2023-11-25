import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { PasswordValidators } from "../form-validators";
import { RegistrationFormDataService } from '../form-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'registration-first-step',
  templateUrl: 'first-step.component.html'
})
export class FirstStepComponent {
  isSubmitted = false;

  registerForm = this.fb.group({
    login: [, {
      validators: [
        Validators.required,
        Validators.email,
        Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'),
        Validators.max(255)
      ], updateOn: "change",
    }],
    password: [, {
      validators:
        [
          Validators.required,
          PasswordValidators.patternValidator(new RegExp("(?=.*[0-9A-Z])(?=.*[A-Z])(?=.*[0-9])"), { requiresDigitAndLetter: true }),
          Validators.max(255)
        ], updateOn: "change"
    }],
    confirmPassword: [, {
      validators:
        [
          Validators.required,
          Validators.max(255)
        ], updateOn: "change"
    }],
    acceptTerms: [false, { validators: [Validators.requiredTrue], updateOn: 'change' }]
  }, {
    validators: [PasswordValidators.passwordMatch('password', 'confirmPassword')],
    updateOn: 'change',
  });

  constructor(
    private readonly fb: FormBuilder, 
    private readonly router: Router,
    private readonly formDataService: RegistrationFormDataService) { }

  onSubmit() {
    this.isSubmitted = true;
    if (this.registerForm.valid) {
      this.formDataService.setFirstStepData(this.registerForm.value);
      this.router.navigate(['/second']);
    }
  }
}
