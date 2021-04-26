import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category.model';
import { Observable, EMPTY } from "rxjs";
import { catchError, map } from 'rxjs/operators';
import { CustomSnackBarService } from '../components/message/custom-snack-bar/custom-snack-bar.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private url: string = 'https://localhost:44368/category'

  constructor(
    private http: HttpClient,
    private customSnackBarService: CustomSnackBarService
  ) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.url).pipe(
      map(p => p),
      catchError(error => this.errorHandler(error))
    );
  }

  getCategoryById(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.url}/${id}`).pipe(
      map(p => p),
      catchError(error => this.errorHandler(error))
    );
  }

  insertCategory(category: Category): Observable<any> {
    return this.http.post<Category>(this.url, category, httpOptions).pipe(
      map(p => p),
      catchError(error => this.errorHandler(error))
    );
  }

  updateCategory(id: number, category: Category): Observable<any> {
    return this.http.put<Category>(`${this.url}/${id}`, category, httpOptions).pipe(
      map(p => p),
      catchError(error => this.errorHandler(error))
    );
  }

  deleteCategory(id: number): Observable<any> {
    return this.http.delete<number>(`${this.url}/${id}`, httpOptions).pipe(
      map(p => p),
      catchError(error => this.errorHandler(error))
    );
  }

  errorHandler(error: any): Observable<any> {
    this.customSnackBarService.errorMessage("An error has occurred")
    return EMPTY
  }
}
