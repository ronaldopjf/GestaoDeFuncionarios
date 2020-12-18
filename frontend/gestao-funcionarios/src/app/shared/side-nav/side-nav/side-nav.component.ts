import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { EmployeeForRead } from 'src/app/models/employee/employeeForRead';

import { HeaderService } from 'src/app/services/header.service';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {

  public employeeForDetails: EmployeeForRead;
  public showSideNav = false;
  private subscription: Subscription;

  public constructor(private headerService: HeaderService) { }

  public ngOnInit(): void {
    this.subscription = this.headerService.get().subscribe(result => this.showSideNav = result);
    this.headerService.getEmployeeForRead().subscribe(result => this.employeeForDetails = result);
  }

  public ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public hideSideNav(): void {
    this.headerService.toggle();
  }
}
