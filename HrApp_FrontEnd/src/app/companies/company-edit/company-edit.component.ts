import { Location } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Company } from 'src/app/models/company';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-company-edit',
  templateUrl: './company-edit.component.html',
  styleUrls: ['./company-edit.component.css']
})
export class CompanyEditComponent implements OnInit {
  @Input() company!: Company;

  constructor(private companyService: CompanyService,
              private location: Location,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.getCompany;
  }

  getCompany(): void{
    const companyId = Number(this.route.snapshot.paramMap.get('companyId'));
    this.companyService.getCompany(companyId)
      .subscribe(company => this.company = company);
  }

  editCompany(companyName: string, companyAddress: string, companyInformation: string): void {
    const companyId = Number(this.route.snapshot.paramMap.get('companyId'));
    companyName = companyName;
    companyAddress = companyAddress;
    companyInformation = companyInformation;
    this.companyService.editCompany(companyId, { companyAddress,companyInformation,companyName} as Company)
      .subscribe();
  }

  goBack() {
    this.location.back();
  }
}
