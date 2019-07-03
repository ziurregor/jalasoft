import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpHeaders } from '@angular/common/http';
// import { RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import { User } from './user/user.model';
// import { Observable } from 'rxjs/Observable';

@Injectable()
export class LoginService {

  URL: string;
  httpOptions: any;
  headers: any;
  Users :User[];
  constructor(private http: HttpClient) {
    
    this.URL = 'http://localhost:23997/api/users';
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


  PostData(username: any): Observable<User> {
    return this.http.post<User>(this.URL,username); 
  }
  GetData(): Observable<any> {
    return this.http.get<any>(this.URL); 
  }


  addData (item: any): Observable<any> {
    return this.http.post<any>(this.URL, item, this.headers);
  }


}