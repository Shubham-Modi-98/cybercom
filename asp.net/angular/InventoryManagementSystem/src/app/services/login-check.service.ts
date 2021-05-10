import { Injectable, NgModule, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class LoginCheckService implements OnInit {

  private adminCheck:any;
  private jsonData:any;

  constructor(private router:Router,
    ) { }
  ngOnInit(): void {
  }

  checkUser(): void {
    this.adminCheck = sessionStorage.getItem('userCred');
    this.jsonData = JSON.parse(this.adminCheck);
    // console.log(this.adminCheck.userName);
    // console.log(this.adminCheck.password);
    if(this.jsonData == null)  
    {
      this.router.navigateByUrl('');
    }
    else 
    {
      if (this.jsonData["userName"] !== "Admin@user.com" && this.jsonData["password"] !== "Admin@12345") {
        this.router.navigateByUrl('');
      }
    }
  }
}
