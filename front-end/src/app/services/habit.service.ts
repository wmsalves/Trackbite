import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HabitService {
  private apiUrl = `${environment.apiUrl}/api/habits`;

  constructor(private http: HttpClient) {}

  getHabits(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
