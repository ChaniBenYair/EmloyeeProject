import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { JobService } from '../../job/job.service';
import { Job } from '../../../models/job.model';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { CommonModule } from '@angular/common';
import { Emloyee } from '../../../models/employee.model';
import { EmploeeService } from '../emploee.service';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { JobEmployee } from '../../../models/jobEmployee.model';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatDialogModule,
    MatSelectModule,
    HttpClientModule,
    MatOptionModule,
    CommonModule,
    MatDatepickerModule,
    MatExpansionModule,
    MatIconModule
  ],
  providers: [JobService, EmploeeService],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css'
})
export class AddEmployeeComponent implements OnInit {

  employeeForm!: FormGroup;
  jobForm!: FormGroup;
  employee!: Emloyee;
  jobEmployee: JobEmployee[]
  jobs!: Job[]

  constructor(private fb: FormBuilder,
    private dialog: MatDialog,
    private _jobService: JobService,
    private _employeeService: EmploeeService) {
    this.employee = {} as Emloyee;
    this.jobEmployee = [];
  }

  ngOnInit() {

    console.log("succ")
    this._jobService.getJob().subscribe(
      (resJobs: Job[]) => {
        this.jobs = resJobs
      }
    )

    this.employeeForm = this.fb.group({
      idEmployee: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      startOfWorkDate: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      isMale: [false],
      job: [[], Validators.required],
    });
    
    this.jobForm = this.fb.group({
      jobId: ['', Validators.required],
      dateStartJob: ['', Validators.required],
      isManagerialPosition: [false]
    });
  }

  onSubmit(): void {
    const dob = new Date(this.employeeForm.value.dateOfBirth);
    const sowd = new Date(this.employeeForm.value.startOfWorkDate);
    if (dob > sowd) {
      console.error("Date of Birth must be earlier than Start of Work Date")
      return;
    }
    this.employee = this.employeeForm.value;
    this.employee.job = this.jobEmployee
    console.log(this.employee)
    this._employeeService.addEmployee(this.employee).subscribe(
      (rec: Emloyee) => {
        console.log(rec);
      }
    )
  }
  showInputs: boolean = true;

  addJob(): void {
    this.showInputs = true
  }
  getJob(): void {
    const selectedJobId = this.jobForm.get('jobId')?.value;
    const newJob = this.jobs.find(j => j == selectedJobId)
    const jobsWithoutSelected = this.jobs.filter(job => job == newJob);
    console.log(jobsWithoutSelected)
    this.jobs = jobsWithoutSelected;
    this.jobEmployee.push(this.jobForm.value)
    this.showInputs = false
  }

}




