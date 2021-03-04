import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { MovieInterface } from '../interfaces/movie.interface';
import { Observable } from 'rxjs';
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

export class MovieService {

  baseUrl: string;
  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public GetMovies(): Observable<MovieInterface[]> {
    return this.http.get<MovieInterface[]>(this.baseUrl + "api/movie");
  }

  public SaveMovie(movieModel: MovieInterface): Observable<ResponseInterface> {
    return this.http.post<ResponseInterface>(this.baseUrl + `api/movie`, movieModel, httpOptions);
  }

  public EditMovie(movieModel: MovieInterface): Observable<ResponseInterface> {
    return this.http.put<ResponseInterface>(this.baseUrl + `api/movie/${movieModel.id}`, movieModel, httpOptions);
  }
}
