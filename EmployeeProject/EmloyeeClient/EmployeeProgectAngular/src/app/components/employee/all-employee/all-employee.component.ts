import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable, MatTableModule } from '@angular/material/table';
import { MatTableDataSource } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { EmploeeService } from '../emploee.service';
import { Emloyee } from '../../../models/employee.model';
import { HttpClientModule } from '@angular/common/http';
import Swal from 'sweetalert2';
import { MatIconModule } from '@angular/material/icon';
import { JobService } from '../../job/job.service';
import { Job } from '../../../models/job.model';
import { AddEmployeeComponent } from '../add-employee/add-employee.component';
import { MatDialog } from '@angular/material/dialog';
import { EditEmployeeComponent } from '../edit-employee/edit-employee.component';
import * as XLSX from 'xlsx';
import { Route, Router } from '@angular/router';

export interface PeriodicElement {
  firstName: string;
  lastName: string;
  idEmployee: string;
  dateStartOfWork: Date;
  id: number
}

const EMPLOYEES: PeriodicElement[] = [];

@Component({
  selector: 'app-all-employee',
  standalone: true,
  imports: [
    MatButtonModule,
    MatTableModule,
    MatInputModule,
    MatFormFieldModule,
    HttpClientModule,
    MatIconModule,
  ],
  providers: [EmploeeService, JobService],
  templateUrl: './all-employee.component.html',
  styleUrl: './all-employee.component.css'
})
export class AllEmployeeComponent implements OnInit {

  displayedColumns: string[] = ['firstName', 'lastName', 'idEmployee', 'dateStartOfWork', 'edit', 'delete'];
  dataSource = new MatTableDataSource<PeriodicElement>(EMPLOYEES);
  @ViewChild(MatTable) table?: MatTable<PeriodicElement>;
  public employees!: Emloyee[];
  public employee!: Emloyee;
  public jobs!: Job[];
  public jobForAdd: Job[] = []
  public job!: Job
  public nameJob!: string
  public jobId: number = 0;
  id!: number
  constructor(private _employeeService: EmploeeService,
    private _jobService: JobService,
    private router: Router,
    private dialog: MatDialog) {
    this.employee = {} as Emloyee;
    this.job = {} as Job;
  }

  ngOnInit(): void {
    this._employeeService.getEmployee().subscribe(
      (fetchedEmployees: Emloyee[]) => {
        if (fetchedEmployees.length > 0) {

          console.log(fetchedEmployees);

          fetchedEmployees.forEach((employee) => {
            if (employee.isActive == true) {
              EMPLOYEES.push({
                firstName: employee.firstName,
                lastName: employee.lastName,
                idEmployee: employee.idEmployee,
                dateStartOfWork: employee.startOfWorkDate,
                id: employee.id
              })
              console.log(employee)
            };
          });

          this.dataSource.data = EMPLOYEES;
        } else {
          console.log('לא התקבלו עובדים מהשירות');
        }
      },
      (error) => {
        console.error('שגיאה באחזור עובדים:', error);
      }
    );
    this._jobService.getJob().subscribe(
      (resJobs: Job[]) => {
        this.jobs = resJobs
      }
    )
  }

  async removeData(e: Emloyee) {
    console.log(e)
    Swal.fire({
      title: "Deleted",
      icon: "success"
    });
    console.log(e.id)
    this._employeeService.DeleteEmployee(e.id).subscribe(
      (rec: Emloyee) => {
        console.log(rec)
      }
    )
    // this.router.navigate(['/']);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  editData(e: Emloyee) {
    console.log(e)
    const dialogRef = this.dialog.open(EditEmployeeComponent, {
      width: '500px',
      data: {
        id: e.id
      }
    })
  }
  addEmployee(): void {
    const dialogRef = this.dialog.open(AddEmployeeComponent, {
      width: '500px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
      }
    });
  }
  downloadToExcel() {

    const worksheet = XLSX.utils.json_to_sheet(this.dataSource.data);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, 'Employee Data');
    XLSX.writeFile(workbook, 'employee_data.xlsx');

  }

}
