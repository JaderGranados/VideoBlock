import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonaInterface } from '../interfaces/persona.interface';
import { ResponseInterface } from '../interfaces/response.interface';

const httpOptions = {
  headers: new HttpHeaders({
    "Content-Type": "application/json",
    "Authorization": "my-token"
  })
}

@Injectable({
  providedIn: 'root'
})

export class PersonaService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getAll(): Observable<PersonaInterface[]> {
    return this.http.get<PersonaInterface[]>(this.baseUrl + `api/persona`);
  }

  public save(persona: PersonaInterface): Observable<ResponseInterface> {
    return this.http.post<ResponseInterface>(this.baseUrl + `api/persona`, persona, httpOptions);
  }
}
