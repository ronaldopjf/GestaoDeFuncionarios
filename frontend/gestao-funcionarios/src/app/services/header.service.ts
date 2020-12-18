import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { EmployeeForRead } from '../models/employee/employeeForRead';

@Injectable()
export class HeaderService {

    private isDisplayed = false;
    private showSideNavSubject = new Subject<boolean>();
    private employeeForRead = new Subject<EmployeeForRead>();

    public constructor() { }

    public toggle(): void {
        this.isDisplayed = !this.isDisplayed;
        this.showSideNavSubject.next(this.isDisplayed);
    }

    public get(): Observable<boolean> {
        return this.showSideNavSubject.asObservable();
    }

    public setEmployeeForRead(employeeForRead: EmployeeForRead): void {
        this.employeeForRead.next(employeeForRead);
    }

    public getEmployeeForRead(): Observable<EmployeeForRead> {
        return this.employeeForRead.asObservable();
    }
}