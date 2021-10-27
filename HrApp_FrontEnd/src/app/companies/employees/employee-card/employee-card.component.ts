import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Company } from 'src/app/models/company';
import { Employee } from 'src/app/models/employee';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-employee-card',
  templateUrl: './employee-card.component.html',
  styleUrls: ['./employee-card.component.css']
})
export class EmployeeCardComponent implements OnInit {
  @Input() public employee!: Employee;

  constructor(private companyService: CompanyService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.getEmployee();
  }

  getEmployee() {
    const employeeId = Number(this.route.snapshot.paramMap.get('employeeId'));
    this.companyService.getEmployee(employeeId)
      .subscribe(employee => this.employee = employee);
  }

  deleteEmployee() {
    this.companyService.deleteEmployee(this.employee.employeeId).subscribe();
    window.location.reload();
  }

}
