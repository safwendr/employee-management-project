import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthModel, UserInput } from './auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private isAuthenticated$ = new BehaviorSubject<boolean>(false);
  public isAuthenticated = this.isAuthenticated$.asObservable();

  private loggedUser$ = new BehaviorSubject<AuthModel>({});
  public loggedUser = this.loggedUser$.asObservable();

  constructor(
    private http: HttpClient
  ) { }

  login(userInput: UserInput) {
    return this.http.post<AuthModel>(`${environment.baseUrl}/auth/sign-in`, userInput).pipe(
      tap(
        {
          next: res => {
            this.isAuthenticated$.next(true);
            this.loggedUser$.next(res);
          }
        }
      )
    );
  }
}
