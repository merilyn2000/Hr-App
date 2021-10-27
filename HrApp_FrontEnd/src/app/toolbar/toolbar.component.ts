import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {

  public constructor(public accountService: AccountService,
              private router: Router) { }

  ngOnInit() {
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/company-list");
  }
}
