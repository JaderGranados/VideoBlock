import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core'
import { Observable } from 'rxjs';
import { ResponseInterface } from '../interfaces/response.interface';
import { UserInterface } from '../interfaces/user.interface';

const httpOptions = {
  headers: new HttpHeaders({
    "Content-Type": "application/json",
    "Authorization": "my-token"
  })
}

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    
  }
  public saveUser(user: UserInterface): Observable<ResponseInterface> {
    return this.http.post<ResponseInterface>(this.baseUrl + "api/user", user, httpOptions);
  }

  public login(user: UserInterface): Observable<ResponseInterface> {
    return this.http.post<ResponseInterface>(this.baseUrl + "api/user/login", user, httpOptions);
  }

  public getUserByUsername(username: string): Observable<ResponseInterface> {
    return this.http.get<ResponseInterface>(this.baseUrl + "api/user/userbyusername/" + username, httpOptions);
  }

  public bookAMovie(idUser: number, idMovie: number): Observable<ResponseInterface> {
    return this.http.get<ResponseInterface>(this.baseUrl + `api/user/bookmovie/${idUser}/${idMovie}`, httpOptions);
  }
}
