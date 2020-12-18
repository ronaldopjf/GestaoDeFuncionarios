import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { BaseService } from './base.service';
import { environment } from 'src/environments/environment';
import { EmployeeForCreateUpdate } from '../models/employee/employeeForCreateUpdate';

@Injectable()
export class EmployeeService extends BaseService {
  private employeeUrl: string;

  public constructor(http: HttpClient) {
    super(http);
    this.employeeUrl = environment.urlAPI + 'employee';
  }

  public getEmployees(): Observable<any> {
    const queryString = this.createQueryString(null);
    return this.get(this.employeeUrl, queryString);
  }

  public getEmployee(id: number): Observable<any> {
    return this.getById(`${this.employeeUrl}/${id}`);
  }

  public createEmployee(employeeForCreate: EmployeeForCreateUpdate): Observable<any> {
    return this.post(this.employeeUrl, employeeForCreate);
  }

  public updateEmployee(employeeForUpdate: EmployeeForCreateUpdate): Observable<any> {
    return this.put(this.employeeUrl, employeeForUpdate);
  }

  public deleteEmployee(id: number): Observable<any> {
    return this.delete(this.employeeUrl, `${id}`);
  }
}