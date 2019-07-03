import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LoginService } from './login.service';
import { FormsModule } from '@angular/forms';
import { ChatroomComponent } from './chatroom/chatroom.component';


@NgModule({
  declarations: [AppComponent,LoginComponent,ChatroomComponent ],
  imports: [ BrowserModule,  AppRoutingModule, HttpClientModule, FormsModule ],
  providers: [LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
