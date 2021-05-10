import { DashboardService } from './../services/dashboard.service';
import { LoaderService } from './../loader/loader.service';
import { LoginCheckService } from './../services/login-check.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  todaysOrders!:any;
  availableProducts!:any;
  lessProducts!:any;

  constructor(private router:Router,
    private loginService:LoginCheckService,
    private spinner:LoaderService,
    private dashboardservice:DashboardService,
    ) { 
      loginService.checkUser();
    }

  ngOnInit(): void {

    try {
      this.spinner.requestStarted();
    // setTimeout(() => {
    //   this.spinner.requestEnded();
    // }, 5000);

    this.dashboardservice.getTodaysOrders()
    .subscribe((response:any) => {
      console.log(response);
      this.todaysOrders = response;
      if(this.todaysOrders == null)
        this.todaysOrders = 0;
      this.spinner.requestEnded();
    },(err) => {
      console.log(err);
      this.spinner.resetSpinner();
    });
    
    this.dashboardservice.getAvailableProducts()
    .subscribe((response:any) => {
      this.availableProducts = response;
      if(this.availableProducts == null)
        this.availableProducts = 0;
      this.spinner.requestEnded();
    },(err) => {
      console.log(err);
      this.spinner.resetSpinner();
    });

    this.dashboardservice.getLessProducts()
    .subscribe((response:any) => {
      this.lessProducts = response;
      if(this.lessProducts == null)
        this.lessProducts = 0;
      this.spinner.requestEnded();
    },(err) => {
      console.log(err);
      this.spinner.resetSpinner();
    });
    } catch (error) {
      console.log(error);
      this.spinner.resetSpinner();
    }
  }

}
