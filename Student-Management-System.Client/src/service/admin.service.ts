import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAdmin } from 'src/app/Interface/IAdmin';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  private apiUrl = 'https://localhost:7015/api/Admin';

  constructor(private http: HttpClient) { }

  getAdmin(): Observable<IAdmin> {
    return this.http.get<IAdmin>(`${this.apiUrl}`);
  }

  addAdmin(admin: IAdmin): Observable<IAdmin> {
    return this.http.post<IAdmin>(`${this.apiUrl}`, admin);
  }

}
