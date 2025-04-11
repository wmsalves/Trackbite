import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HabitService } from '../../services/habit.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  standalone: true,
  imports: [],
})
export class DashboardComponent implements OnInit {
  habits: any[] = [];

  constructor(private habitService: HabitService) {}

  ngOnInit(): void {
    this.habitService.getHabits().subscribe({
      next: (data) => {
        this.habits = data;
        console.log('Habits from API:', data);
      },
      error: (err) => {
        console.error('Failed to fetch habits:', err);
      }
    });
  }
}
