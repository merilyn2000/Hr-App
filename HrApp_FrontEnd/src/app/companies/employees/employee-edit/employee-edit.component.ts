import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from 'src/app/models/employee';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {
  employee!: Employee;

  constructor(private companyService: CompanyService,
              private location: Location,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.getEmployee();
  }

  getEmployee(): void{
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.companyService.getEmployee(id)
      .subscribe(employee => this.employee = employee);
  }

  editEmployee(firstName: string, lastName: string): void {
    const Id = Number(this.route.snapshot.paramMap.get('id'));
    firstName = firstName;
    lastName = lastName;
    this.companyService.editEmployee(Id, { firstName, lastName } as Employee)
      .subscribe();
  }

  goBack() {
    this.location.back();
  }
}
