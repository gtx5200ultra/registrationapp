import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { PasswordValidators } from "../form-validators";

@Component({
  selector: 'registration-first-step',
  templateUrl: 'first-step.component.html'
})
export class FirstStepComponent {
  //model: User = new User;

  registerForm = this.fb.group({
    login: [, { validators: [Validators.required, Validators.email, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')], updateOn: "change" }],
    password: [, {
      validators:
        [
          Validators.required,
          PasswordValidators.patternValidator(new RegExp("(?=.*[0-9A-Z])(?=.*[A-Z])(?=.*[0-9])"), { requiresDigitAndLetter: true })
        ], updateOn: "change"
    }],
    confirmPassword: [, {
      validators:
        [
          Validators.required
        ], updateOn: "change"
    }],
  }, {
    validators: [PasswordValidators.passwordMatch('password', 'confirmPassword')],
    updateOn: 'change',
  });

  constructor(public fb: FormBuilder) { }

  onSubmit() {
  }
}
