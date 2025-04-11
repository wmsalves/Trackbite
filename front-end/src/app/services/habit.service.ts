import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

export interface Habit {
  id: number;
  title: string;
  description: string;
}

@Injectable({
  providedIn: 'root'
})

export class HabitService {
  private apiUrl = 'https://localhost:5001/api/habits'

  constructor(private http: HttpClient) {}

  getHabits(): Observable<Habit[]> {
    return this.http.get<Habit[]>(this.apiUrl);
  }
}