import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private baseUrl: string = `https://localhost:44360/account`;

  private currentUserSource =  new ReplaySubject<User>(1);
  public currentUser$ = this.currentUserSource.asObservable();


  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post<User>(`${this.baseUrl}/login`, model).pipe(
      map((response: User) => {
        const user = response;
        if(user) {
          this.setCurrentUser(user)
        }
      })
    );
  }

  register(model: any) {
    return this.http.post<User>(`${this.baseUrl}/register`, model).pipe(
      map((user: User) => {
        if(user) {
          this.setCurrentUser(user)
        }
      })
    );
  }

  setCurrentUser(user: User) {
    user.roles = [];
    const roles = this.getDecodateToken(user.token).role;
    Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);

    this.currentUserSource.next(user);
  }

  logout() {
    this.currentUserSource.next(undefined);
  }

  getDecodateToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }
}
