// import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
// import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
   constructor(private http: HttpClient) { }
 
  // title = 'chat';
  // name = 'Angular 4';

  result;
  errorFromSubscribe;
  // errorFromCatch;
  displayItems;

  // constructor(private http: Http) { }
  ngOnInit() {}

  onClick() {
    return this.http.get("http://localhost:8080/resteasyexamples/rest/products");

    // this.http.get('https://localhost:5001/api/values')
    //   .subscribe((res: Response) => {
    //     this.result = res.json();
    //     this.displayItems = this.result;
    //   }, error => {
    //     console.log(error);
    //     this.errorFromSubscribe = error;
    //   });
  }
}
