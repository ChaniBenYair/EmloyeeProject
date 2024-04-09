import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Emloyee } from '../../models/employee.model';
import { JobEmployee } from '../../models/jobEmployee.model';

@Injectable({
  providedIn: 'root'
})

export class EmploeeService {

  constructor(private http: HttpClient) { }
  private apiUrl = 'https://localhost:7134/api';

  getEmployee(): Observable<Emloyee[]> {
    console.log("okkkk");
    return this.http.get<Emloyee[]>(`${this.apiUrl}/Employee`);
  }

  getEmployeeById(id:number): Observable<Emloyee>{
    console.log("id in service",id)
    return this.http.get<Emloyee>(`${this.apiUrl}/Employee/${id}`)
  }

  addEmployee(employee: Emloyee): Observable<Emloyee> {
    console.log("jbh")
    return this.http.post<Emloyee>(`${this.apiUrl}/Employee`, employee);
  }

  DeleteEmployee(id: number): Observable<Emloyee>{
    return this.http.delete<Emloyee>(`${this.apiUrl}/Employee/${id}`)
  }

  updateEmployee(employee: Emloyee, id: number):Observable<Emloyee>{
    return this.http.put<Emloyee>(`${this.apiUrl}/Employee/${id}`,employee)
  }
  getJobEmployee(): Observable<JobEmployee[]> {
    console.log("okkkk");
    return this.http.get<JobEmployee[]>(`${this.apiUrl}/JobEmployee`);
  }
}
