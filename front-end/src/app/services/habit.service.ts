import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HabitService {
  private baseUrl = `${environment.apiUrl}/habits`;

  constructor(private http: HttpClient) {}

  getHabits() {
    return this.http.get(this.baseUrl);
  }
}
