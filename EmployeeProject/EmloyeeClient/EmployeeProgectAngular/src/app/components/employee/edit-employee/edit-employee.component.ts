import { EmploeeService } from '../emploee.service';
import { Emloyee } from '../../../models/employee.model';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose } from '@angular/material/dialog';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { JobService } from '../../job/job.service';
import { Job } from '../../../models/job.model';
import { HttpClientModule } from '@angular/common/http';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { JobEmployee } from '../../../models/jobEmployee.model';

export interface DialogData {
  id: number
}

@Component({
  selector: 'app-edit-employee',
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
    MatFormFieldModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
  ],
  providers: [EmploeeService, JobService],
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.css'
})
export class EditEmployeeComponent implements OnInit {
  employee!: Emloyee;
  jobs!: Job[]
  id!: number;
  jobEmployees!: JobEmployee[]
  jobEmployee!: JobEmployee
  resJE!: JobEmployee[]
  employeeForm!: FormGroup;
  jobForm!: FormGroup
  EId!: number

  constructor(private _employeeService: EmploeeService,
    private dialog: MatDialog,
    private fb: FormBuilder,
    private _jobService: JobService, public dialogRef: MatDialogRef<EditEmployeeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {
    this.id = data.id;
    this.employee = {} as Emloyee;
    this.jobEmployees = {} as JobEmployee[];

  }

  ngOnInit(): void {
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
      job: [[], Validators.required]
    });
    this.jobForm = this.fb.group({
      jobId: ['', Validators.required],
      dateStartJob: ['', Validators.required],
      isManagerialPosition: [false]
    });

    console.log(this.id)
    this._employeeService.getEmployeeById(this.id).subscribe(
      (rec: Emloyee) => {
        this.EId = rec.id
        console.log(rec)
        this.employeeForm.patchValue({
          idEmployee: rec.idEmployee,
          firstName: rec.firstName,
          lastName: rec.lastName,
          startOfWorkDate: rec.startOfWorkDate,
          dateOfBirth: rec.dateOfBirth,
          isMale: rec.isMale,
        });
      }
    )
    this._employeeService.getJobEmployee().subscribe(
      (res: JobEmployee[]) => {
        this.resJE = res
        const temp = this.resJE.filter(t => t.employeeId == this.EId)
        this.resJE = temp;

        const formValues = this.resJE?.map(jobEmployee => ({
          jobId: jobEmployee.jobId,
          dateStartJob: jobEmployee.dateStartJob,
          isManagerialPosition: jobEmployee.isManagerialPosition,
        }));
        this.jobForm.setValue({
          jobId: formValues.map(val => val.jobId),
          dateStartJob: formValues.map(val => val.dateStartJob),
          isManagerialPosition: formValues.map(val => val.isManagerialPosition),
        });
        console.log(this.jobForm)
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
    const jobsWithoutSelected = this.jobs.filter(job => job !== newJob);
    this.jobs = jobsWithoutSelected;
    this.jobEmployees.push(this.jobForm.value)
    this.showInputs = false
  }

  onSubmit() {

    this.employee = this.employeeForm.value;
    this.employee.job = []
    console.log(this.employee)
    this._employeeService.updateEmployee(this.employee, this.id).subscribe(
      (res: Emloyee) => {
        console.log(res)
      }
    )
  }
}
