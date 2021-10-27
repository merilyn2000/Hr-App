import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  notfound() {
    this.http.get(`${environment.companiesUrl}nonExistentEndpoint`).subscribe(
      (success) => console.log(success),
      (error) => console.log(error)
    );
  }

}
