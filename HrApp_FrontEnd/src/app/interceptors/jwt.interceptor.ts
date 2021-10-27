import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { AccountService } from '../services/account.service';
import { User } from '../models/user';
import { catchError, take } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private accountService: AccountService,
              private router: Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let currentUser!: User;

    this.accountService.currentUser$.pipe(take(1)).subscribe(user => currentUser = user);
    if(currentUser) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${currentUser.token}`
        }
      })
    }//pipe = se adauga inca o operatiune
    return next.handle(request).pipe(
      catchError( (errorResponse: HttpErrorResponse) => {
          if(errorResponse) {
            switch (errorResponse.status) {
              case 401:
                this.router.navigateByUrl("/login");
                console.warn("The authentiocation session expired. Please signin again")
                break;
              // case 404:
              //   this.router.navigateByUrl("/not-found");
              //   console.warn("404 error was handled")
              //   break;
              case 500:
                this.router.navigateByUrl("/server-error");
                console.warn("500 error was handled")
                break;
              default:
                console.warn("An unexpected error was handled. Please contact the administrator of the system")
                break;
            }
          }
          return throwError(errorResponse);
        }
      )
    );
  }
}
