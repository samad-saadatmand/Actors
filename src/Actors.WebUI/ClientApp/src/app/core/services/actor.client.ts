import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, InjectionToken, Optional } from '@angular/core';
import { Observable } from 'rxjs';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable({
  providedIn: 'root',
})
export class ActorClient {
  private http: HttpClient;
  private baseUrl: string;

  constructor(
    @Inject(HttpClient) http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.http = http;
    this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : '';
  }

  getActors(): Observable<any> {
    return this.http.get(`${this.baseUrl}actors`);
  }

  getActor(id: string): Observable<any> {
    return this.http.get(`${this.baseUrl}actors/${id}`);
  }

  getActorMovies(id: string): Observable<any> {
    return this.http.get(`${this.baseUrl}actors/${id}/movies`);
  }

  addActor(firstName: string, lastName: string, age: number): Observable<any> {
    return this.http.post(`${this.baseUrl}actors`, {
      firstName,
      lastName,
      age,
    });
  }

  addActorMovie(
    id: string,
    movieName: string,
    movieReleaseDate: string
  ): Observable<any> {
    return this.http.post(`${this.baseUrl}actors/${id}/movie`, {
      movieName,
      movieReleaseDate,
    });
  }
}
