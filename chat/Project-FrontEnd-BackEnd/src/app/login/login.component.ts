import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';
import { stringify } from 'querystring';
import { Subscriber } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {
  
  
  userName: string;
  response: any;

  constructor(private loginService: LoginService) { 

  }
    ngOnInit() {
    }

    onSubmit(){
    // debugger;

    this.loginService.PostData(this.userName).subscribe( res => {

      console.log('res ' + res);
    });

  }
  

}
