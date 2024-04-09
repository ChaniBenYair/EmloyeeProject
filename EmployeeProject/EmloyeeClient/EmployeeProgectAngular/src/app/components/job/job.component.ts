import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-job',
  standalone: true,
  imports: [HttpClientModule],
  templateUrl: './job.component.html',
  styleUrl: './job.component.css'
})
export class JobComponent {

}
