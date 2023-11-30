import { ErrorHandler, Injectable, Injector, Inject } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class GlobalErrorHandler extends ErrorHandler {

    constructor(
        @Inject(Injector) private readonly injector: Injector
    ) {
        super();
    }

    override handleError(errorResponse: HttpErrorResponse) {
        this.toastrService.error(errorResponse.error, '', { onActivateTick: true });
    }

    private get toastrService(): ToastrService {
        return this.injector.get(ToastrService);
    }
}
