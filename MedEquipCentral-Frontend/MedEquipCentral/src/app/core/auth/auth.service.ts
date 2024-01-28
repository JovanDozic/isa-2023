import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { TokenStorage } from './jwt/token.service';
import { environment } from "../../shared/environment";
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticationResponse } from './model/authentication-response.model';
import { User, UserRole } from './model/user.model';
import { Registration } from './model/registration.model';
import { Login } from "./model/login.model";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user$ = new BehaviorSubject<User>({ id: 0, email: "", password: "", confirmPassword: "", name: "", surname: "", city: "", country: "", phone: "", job: "", companyInfo: "", userRole: UserRole.Unauthenticated });

  constructor(private http: HttpClient,
    private tokenStorage: TokenStorage,
    private router: Router) { }

    login(login: Login): Observable<AuthenticationResponse> {
      return this.http
        .post<AuthenticationResponse>(environment.apiHost + 'users/login', login)
        .pipe(
          tap(
            (authenticationResponse) => {
              this.tokenStorage.saveAccessToken(authenticationResponse.accessToken);
              this.setUser();
            },
            (error) => {
              alert("Invalid credentials");
              console.error('Login failed:', error);
            }
          )
        );
    }

  register(registration: Registration): Observable<AuthenticationResponse> {
    return this.http
      .post<AuthenticationResponse>(environment.apiHost + 'users/register', registration)
      .pipe(
        tap((authenticationResponse) => {
          this.tokenStorage.saveAccessToken(authenticationResponse.accessToken);
          this.setUser();
        })
      );
  }

  logout(): void {
    this.router.navigate(['/home']).then(_ => {
      this.tokenStorage.clear();
      this.user$.next({
        companyInfo: "", email: "", id: 0, password: "", confirmPassword: "", name: "", surname: "", city: "", country: "", phone: "", job: "", userRole: UserRole.Unauthenticated
      });
    }
    );
  }

  checkIfUserExists(): void {
    const accessToken = this.tokenStorage.getAccessToken();
    if (accessToken == null) {
      return;
    }
    this.setUser();
  }

  verify(userId: number): Observable<AuthenticationResponse> {
    return this.http.
      patch<AuthenticationResponse>(environment.apiHost + "users/verify/" + userId, null)
  }

  private setUser(): void {
    const jwtHelperService = new JwtHelperService();
    const accessToken = this.tokenStorage.getAccessToken() || "";
    id: +jwtHelperService.decodeToken(accessToken).id;
    const user: User = {
      id: +jwtHelperService.decodeToken(accessToken).id,
      email: jwtHelperService.decodeToken(accessToken).email,
      userRole: jwtHelperService.decodeToken(accessToken).userRole,
      name: jwtHelperService.decodeToken(accessToken).name,
      surname: jwtHelperService.decodeToken(accessToken).surname,
      companyId: jwtHelperService.decodeToken(accessToken).companyId,
      isFirstLogin: jwtHelperService.decodeToken(accessToken).isFirstLogin,
    };
    this.user$.next(user);
  }
}
