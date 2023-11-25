import { Injectable, inject } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ApiResponseInterceptor implements HttpInterceptor {

  urlsToNotUse: Array<string> = [];

  constructor() {
    this.urlsToNotUse = [
      'controller/action/.+'
    ];
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const toastr = inject(ToastrService);

    if (request.url.indexOf('api/') < 0) {
      return next.handle(request);
    }

    return next.handle(request).pipe(
      map(response => {
        console.log(response);
        if (response instanceof HttpResponse) {
          if (response.status === 200 && response.body) {
            return response.clone({ body: response.body.data });
          }
        }
        return response;
      }),
      catchError((errorResponse) => {
        toastr.error(errorResponse.error.errorMessage);
        throw errorResponse;
      })
    );
  }
}