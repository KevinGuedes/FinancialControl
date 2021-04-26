import { Type } from './../models/type.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, EMPTY } from "rxjs";
import { catchError, map } from 'rxjs/operators';
import { CustomSnackBarService } from '../components/message/custom-snack-bar/custom-snack-bar.service';

@Injectable({
  providedIn: 'root'
})
export class TypeService {

  private url: string = 'https://localhost:44368/type'

  constructor(
    private http: HttpClient,
    private customSnackBarService: CustomSnackBarService
  ) { }

  getTypes(): Observable<Type[]> {
    return this.http.get<Type[]>(this.url).pipe(
      map(p => p),
      catchError(error => this.errorHandler(error))
    );
  }

  errorHandler(error: any): Observable<any> {
    this.customSnackBarService.errorMessage("An error has occurred")
    return EMPTY
  }
}
