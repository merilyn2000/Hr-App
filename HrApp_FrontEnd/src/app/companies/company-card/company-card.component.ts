import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Company } from 'src/app/models/company';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-company-card',
  templateUrl: './company-card.component.html',
  styleUrls: ['./company-card.component.css']
})
export class CompanyCardComponent implements OnInit {
  @Input() public company!: Company;

  constructor(private companyService: CompanyService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.getCompany();
  }

  getCompany() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.companyService.getCompany(id)
      .subscribe(company => this.company = company);
  }

  deleteCompany() {
    this.companyService.deleteCompany(this.company.id).subscribe();
    window.location.reload();
  }
}
