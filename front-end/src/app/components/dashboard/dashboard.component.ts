import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; // 👈 importa o módulo com *ngFor, *ngIf etc

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent {
  habits = [
    { name: 'Drink Water', completed: true },
    { name: 'Exercise', completed: false },
    { name: 'Read a Book', completed: true },
  ];

  foods = [
    { name: 'Banana', calories: 89 },
    { name: 'Chicken Breast', calories: 165 },
    { name: 'Rice', calories: 130 },
  ];
}
