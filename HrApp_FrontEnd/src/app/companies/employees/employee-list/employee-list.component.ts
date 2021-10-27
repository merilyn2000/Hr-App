import { Location } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Company } from 'src/app/models/company';
import { Employee } from 'src/app/models/employee';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];
  @Input() employee! : Employee;
  @Input() company! : Company;

  public constructor(private companyService: CompanyService,
                      private route: ActivatedRoute,
                      private location: Location) { }

  public ngOnInit(): void {
     this.getEmployees();
     this.getCompany();
  }

  getEmployees() {
    const id = Number(this.route.snapshot.paramMap.get('companyId'));
    this.companyService.getEmployees(id)
      .subscribe(employees => this.employees = employees);
  }

  getCompany() {
    const companyId = Number(this.route.snapshot.paramMap.get('companyId'));
    this.companyService.getCompany(companyId).subscribe(company => {
      this.company = company;
    })
  }

   addEmployee(firstName: string, lastName: string, PersonalIdentificationNumber: string, BirthPlace: string){
     firstName = firstName;
     lastName = lastName;
     PersonalIdentificationNumber = PersonalIdentificationNumber;
     BirthPlace = BirthPlace
     this.companyService.addEmployee(this.company.id, { firstName, lastName,
                                                        PersonalIdentificationNumber, BirthPlace } as Employee)
       .subscribe(employee => {
         this.employees.push(employee);
       });
       this.getEmployees();
   }

  goBack() {
    this.location.back();
  }
}
