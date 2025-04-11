import { Component, OnInit } from '@angular/core';
import { HabitService, Habit } from '../../services/habit.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  habits: Habit[] = [];

  constructor(private habitService: HabitService) {}

  ngOnInit(): void {
    this.habitService.getHabits().subscribe({
      next: (data) => this.habits = data,
      error: (err) => console.error('Erro ao buscar hábitos:', err)
    });
  }
}
