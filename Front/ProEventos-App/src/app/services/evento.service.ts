import { Evento } from './../models/Evento';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable(
  //{providedIn: 'root'}
)
export class EventoService {

  baseURL = 'https://localhost:5001/api/evento/GetAllEventos';

  constructor(private http: HttpClient) { }

  getEventos() : Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL);
  }

  getEventosByTema(tema: string) : Observable<Evento[]> {
    return this.http.get<Evento[]>( `${this.baseURL}?tema=${tema}`);
  }

  getEventoById(id: number) : Observable<Evento> {
    return this.http.get<Evento>(`${this.baseURL}?id=${id}`);
  }

}
