import { Component, OnInit } from '@angular/core';
import { Company } from 'src/app/models/company';
import { AccountService } from 'src/app/services/account.service';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit {
  companies: Company[] = [];

  constructor(private companyService: CompanyService,
              public accountService: AccountService) { }

  ngOnInit(): void {
    this.getCompanies();
  }

  getCompanies() {
    this.companyService.getCompanies().subscribe(companies => {
      this.companies = companies;
    })
  }

  addCompany(companyName: string,companyAddress: string, companyInformation: string,
              companyLogo: string) {
    companyName = companyName;
    companyAddress = companyAddress;
    companyInformation = companyInformation;
    companyLogo = companyLogo;
    this.companyService.addCompany({ companyName, companyAddress, companyInformation, companyLogo } as Company)
      .subscribe(company => {
        this.companies.push(company);
        window.location.reload();
      });
  }
}
