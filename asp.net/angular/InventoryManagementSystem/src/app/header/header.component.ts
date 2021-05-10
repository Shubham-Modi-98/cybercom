import { LoginCheckService } from './../services/login-check.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  isUser!:boolean;
  username!:string;

  constructor(private checkUser:LoginCheckService) {
    checkUser.checkUser();
  }

  ngOnInit(): void {
    let user = sessionStorage.getItem('userCred');
    let jsonUser = JSON.parse(user!);
    if(jsonUser != null) {
      this.isUser = true;
      this.username =  jsonUser["userName"];
    }
    else {
      this.isUser = false;
      this.username =  "User";
    }
  }

}
