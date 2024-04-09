import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Job } from '../../models/job.model';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private http: HttpClient) { }
  private apiUrl = 'https://localhost:7134/api';

  getJob(): Observable<Job[]> {
    console.log("okkkk");
    return this.http.get<Job[]>(`${this.apiUrl}/Job`);
  }

  getJoById(id:number): Observable<Job> {
    console.log("okkkk");
    return this.http.get<Job>(`${this.apiUrl}/Job/${id}`);
  }

  addJob(job:Job):Observable<Job>{
    return this.http.post<Job>(`${this.apiUrl}/Job`,job)
  }

}
