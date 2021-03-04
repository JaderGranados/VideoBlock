import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { SessionModel } from '../models/session.model';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private localStorage;
  private currentSession: SessionModel = null;

  constructor(private router: Router) {
    this.localStorage = localStorage;
    this.currentSession = this.loadSessionData();
    console.log(this.currentSession);
  }

  setCurrentSession(session: SessionModel): void {
    this.currentSession = session;
    this.localStorage.setItem('currentUser', JSON.stringify(session));
  }

  loadSessionData(): SessionModel {
    var sessionStr = this.localStorage.getItem('currentUser');
    return (sessionStr) ? <SessionModel>JSON.parse(sessionStr) : null;
  }

  getCurrentSession(): SessionModel {
    return this.currentSession;
  }

  removeCurrentSession(): void {
    this.localStorage.removeItem('currentUser');
    this.currentSession = null;
  }

  getCurrentUser(): UserModel {
    var session: SessionModel = this.getCurrentSession();
    return (session && session.user) ? session.user : null;
  };

  isAuthenticated(): boolean {
    return (this.getCurrentToken() != null) ? true : false;
  };

  isAdmin(): boolean {
    var session: SessionModel = this.getCurrentSession();
    if (session == null) return false;
    if (session.user == null) return false;
    return (this.getCurrentToken() != null) ? session.user.idRol == 1 : false;
  };

  getCurrentToken(): string {
    var session = this.getCurrentSession();
    return (session && session.token) ? session.token : null;
  };

  logout(): void {
    this.removeCurrentSession();
    this.router.navigate(['/login']);
  }
}
