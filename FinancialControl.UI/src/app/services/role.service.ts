import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EMPTY, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { CustomSnackBarService } from '../components/message/custom-snack-bar/custom-snack-bar.service';
import { Role } from '../models/role.model';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private url: string = 'https://localhost:44368/role'

  constructor(
    private http: HttpClient,
    private customSnackBarService: CustomSnackBarService
  ) { }


  getRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(this.url).pipe(
      map(p => p),
      catchError(error => this.errorHandler(error))
    );
  }

  getRoleById(id: string): Observable<Role> {
    return this.http.get<Role>(`${this.url}/${id}`).pipe(
      map(p => p),
      catchError(error => this.errorHandler(error))
    );
  }

  insertRole(role: Role): Observable<any> {
    return this.http.post<Role>(this.url, role, httpOptions);
  }

  updateRole(id: string, role: Role): Observable<any> {
    return this.http.put<Role>(`${this.url}/${id}`, role, httpOptions);
  }

  deleteRole(id: string): Observable<any> {
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
