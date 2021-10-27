import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public registerForm!: FormGroup;

  constructor(private accountService: AccountService,
              private fb: FormBuilder,
              private router: Router) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4)]]
    });
  }

  register() {
    this.accountService.register(this.registerForm.value).subscribe(() => {
      this.router.navigateByUrl("/company-list");
    }, error => {
      console.log(error);
    });
  }

  cancel() {
    this.router.navigateByUrl("/company-list");
  }

}
