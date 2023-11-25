import { inject } from "@angular/core";
import { RegistrationFormDataService } from "./form-data.service";
import { Router } from "@angular/router";

export const SecondStepGuard = () => {

    return true;

    const registrationFormDataService = inject(RegistrationFormDataService);
    if (!!registrationFormDataService.getFirstStepData()) {
        return true;
    }

    const router = inject(Router);
    router.navigate(['/first']);
    return false;
};