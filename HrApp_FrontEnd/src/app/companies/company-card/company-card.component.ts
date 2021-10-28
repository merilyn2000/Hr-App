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
    this.companyService.getCompany(this.company.id);
  }

  deleteCompany() {
    this.companyService.deleteCompany(this.company.id).subscribe();
    window.location.reload();
  }
}
