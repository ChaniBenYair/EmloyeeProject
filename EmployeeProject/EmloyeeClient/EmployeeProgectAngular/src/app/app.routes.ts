import { Routes } from '@angular/router';
import { AllEmployeeComponent } from './components/employee/all-employee/all-employee.component';
import { AddEmployeeComponent } from './components/employee/add-employee/add-employee.component';

export const routes: Routes = [
    {path:'', redirectTo: 'all-employee', pathMatch: 'full'},
    {path: 'all-employee', component: AllEmployeeComponent},
    {path: 'add-employee', component: AddEmployeeComponent}
];
