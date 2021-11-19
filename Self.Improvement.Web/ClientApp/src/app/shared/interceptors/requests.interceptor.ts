import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export default class RequestsInteceptor implements HttpInterceptor {

    public constructor (
        private router: Router
    ) { }

    public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError((response: HttpResponse<any>) => {
                if (response.status === 401) this.router.navigate['/api/v1/account/google-login'];
                if (response.status === 400 || response.status === 500 || !response?.status) this.router.navigate(['/error/loading'], { queryParams: { redirectUrl: location.pathname } });
                if (response.status === 403) this.router.navigate['/error/access-denied'];

                return throwError(response);
            }));
    }

}
