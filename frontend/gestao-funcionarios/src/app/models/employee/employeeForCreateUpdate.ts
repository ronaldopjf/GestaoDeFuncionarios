export class EmployeeForCreateUpdate {
    id?: number;
    name: string;
    email: string;
    idDepartment: number;
    dateOfBirth: Date;
    primaryPhone: string;
    secondaryPhone: string;
    login: string;
    password: string;
    access: boolean;
    active: boolean
}