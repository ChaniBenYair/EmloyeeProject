import { JobComponent } from "../components/job/job.component";
import { Job } from "./job.model";
import { JobEmployee } from "./jobEmployee.model";

export class Emloyee {
    id!: number
    idEmployee!:string
    firstName!: string
    lastName!: string
    startOfWorkDate!: Date
    dateOfBirth!: Date
    isMale!: boolean
    isActive!: boolean
    job: JobEmployee[] = []

}