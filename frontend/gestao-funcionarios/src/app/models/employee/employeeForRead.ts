import { Department } from '../department/department';

export class EmployeeForRead {
    id?: number;
    name: string;
    email: string;
    department: Department;
    dateOfBirth: Date;
    primaryPhone: string;
    secondaryPhone: string;
    access: boolean;
    active: boolean
}