import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AllEmployeeComponent } from './components/employee/all-employee/all-employee.component';
import { JobComponent } from './components/job/job.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,AllEmployeeComponent,JobComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  
})
export class AppComponent {
  title = 'EmployeeProgectAngular';
}
