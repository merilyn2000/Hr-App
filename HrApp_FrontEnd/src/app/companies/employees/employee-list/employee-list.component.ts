import { Location } from '@angular/common';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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

  public progress!: number;
  public message!: string;
  @Output() public onUploadFinished = new EventEmitter();

  public response!: { dbPath: 'DESKTOP-94QO6UM'};
  public constructor(private companyService: CompanyService,
                      private route: ActivatedRoute,
                      private location: Location,
                      private http: HttpClient) { }

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

   addEmployee(firstName: string, lastName: string, PersonalIdentificationNumber: string,
              BirthPlace: string, photo: string){
     firstName = firstName;
     lastName = lastName;
     PersonalIdentificationNumber = PersonalIdentificationNumber;
     BirthPlace = BirthPlace
     photo = this.response?.dbPath;
     this.companyService.addEmployee(this.company.id, { firstName, lastName, PersonalIdentificationNumber,
                                                        photo, BirthPlace } as Employee)
       .subscribe(employee => {
         this.employees.push(employee);
       });
       this.getEmployees();
   }

  goBack() {
    this.location.back();
  }

  public uploadFile = (files: any) => {
    if (files.length === 0) {
      return;
    }

    let filesToUpload : File[] = files;
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file'+index, file, file.name);
    });

    this.http.post('https://localhost:44360/companies/upload', formData, {reportProgress: true, observe: 'events',
                                                                          responseType: 'text'})
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total!);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
        }
      });
  }

  public uploadFinished = (event: any) => {
    this.response = event;
  }
}
