import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpHeaders } from '@angular/common/http';
// import { RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
// import { Observable } from 'rxjs/Observable';

@Injectable()
export class LoginService {

  URL: string;
  httpOptions: any;
  headers: any;

  constructor(private http: HttpClient) {

    this.URL = 'http://localhost:9940/api/values';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': 'my-auth-token'
      })
    };

    this.headers={
      headers: new HttpHeaders({
          'Content-Type': 'application/json; charset=utf-8',
          'Accept': 'application/json'
      })
    }
  
  }


  PostData(username: any): Observable<any> {
    return this.http.post<any>(this.URL,JSON.stringify(username), {
        headers: {
            'Content-Type': 'application/json'
        }
    });
  }


  addData (item: any): Observable<any> {
    return this.http.post<any>(this.URL, item, this.headers);
  }


}