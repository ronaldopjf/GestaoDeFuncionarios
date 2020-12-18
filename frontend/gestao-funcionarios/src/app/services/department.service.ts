import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

import { BaseService } from './base.service';

@Injectable()
export class DepartmentService extends BaseService {
  private departmentUrl: string;

  public constructor(http: HttpClient) {
    super(http);
    this.departmentUrl = environment.urlAPI + 'department';
  }

  public getDepartments(): Observable<any> {
    const queryString = this.createQueryString(null);
    return this.get(this.departmentUrl, queryString);
  }
}
