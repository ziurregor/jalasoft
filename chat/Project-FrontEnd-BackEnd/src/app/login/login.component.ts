import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';
import { stringify } from 'querystring';
import { Subscriber } from 'rxjs';
import { Router } from '@angular/router';
import { User } from '../user/user.model';
import { debug } from 'util';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {
  
  
  userName: string;
  response: any;
  message: string;
  constructor(private loginService: LoginService, private route : Router) { 
    
  }

    ngOnInit() {
    }

    onSubmit(){
      this.message="User currently on chat.";
    let newUser=new User();
    newUser.email=this.userName;
    this.loginService.PostData(newUser).subscribe( res => {
      newUser = res;
      console.log('res ' + newUser.email);
      
      if (newUser.email){
        this.route.navigate(['chatroom']);
        this.message="";
      }
    });
   


  }
  

}
