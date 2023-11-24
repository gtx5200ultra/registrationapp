import { Component } from '@angular/core';
import { User } from 'src/models/user';

@Component({
  selector: 'registration-first-step',
  templateUrl: 'first-step.component.html'
})
export class FirstStepComponent {
  model: User = new User;

  constructor() { }
}
