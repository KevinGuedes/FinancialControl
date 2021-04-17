import { Type } from './../models/type.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, EMPTY } from "rxjs";
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TypeService {

  private url: string = 'https://localhost:44368/type'

  constructor(
    private http: HttpClient,
  ) { }

  getTypes(): Observable<Type[]> {
    return this.http.get<Type[]>(this.url).pipe(
      map(p => p),
      catchError(error => this.errorHandler(error))
    );
  }

  errorHandler(error: any): Observable<any> {
    // this.customSnackBarService.errorMessage("An error has occurred")
    console.log('deu ruim')
    return EMPTY
  }
}
