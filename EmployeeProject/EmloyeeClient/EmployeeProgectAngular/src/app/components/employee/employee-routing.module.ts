import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';
import { AllEmployeeComponent } from './all-employee/all-employee.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { EditEmployeeComponent } from './edit-employee/edit-employee.component';

const routes: Route[] = [
  {path:'', redirectTo: 'all-employee',pathMatch:'full'},

  {path: 'all-employee', component: AllEmployeeComponent},
  {path: 'add-employee', component:AddEmployeeComponent},
  { path: 'edit-employee/:id', component: EditEmployeeComponent }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class EmployeeRoutingModule { }
