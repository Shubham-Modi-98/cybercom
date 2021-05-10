import { OrderService } from './../services/order.service';
import { Component, OnInit } from '@angular/core';
import { LoginCheckService } from '../services/login-check.service';
import { Router } from '@angular/router';
import { LoaderService } from '../loader/loader.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  totalLength!:number;
  page:number = 1;
  orderData!:any;
  itemsDisplayPerPage:number = 5;
  order:any =  'asc';
  fromDate:string = "";
  toDate:string = "";

  constructor(private orderService:OrderService,
    private userCheckService:LoginCheckService,
    private router:Router,
    private spinnerService:LoaderService,
    ) {
      userCheckService.checkUser();
     }

  ngOnInit(): void {
    try 
    {
      this.spinnerService.requestStarted();
      this.orderService.getAllOrders()
        .subscribe((response: any) => {
          this.orderData = response;
          this.spinnerService.requestEnded();
        }, (err) => {
          console.log(err);
          this.spinnerService.requestEnded();
        });
      
        this.OrderListCount();

    } catch (error) {
      console.log(error);
      this.spinnerService.resetSpinner();
    }
  }

  private OrderListCount(fromDate?:string, toDate?:string)
  {
    this.orderService.getOrdersCount(fromDate,toDate)
        .subscribe((response: any) => {
          this.totalLength = response;
          this.spinnerService.requestEnded();
        }, (err) => {
          console.log(err);
          this.spinnerService.requestEnded();
        });
  }

  pageNo(event:any)
  {
    this.spinnerService.requestStarted();
    this.page = event;
    let recSkip = (event - 1) * this.itemsDisplayPerPage;
    //console.log(this.order);
    this.orderService.getAllOrders(recSkip, this.itemsDisplayPerPage, 'desc',this.fromDate,this.toDate)
      .subscribe((response: any) => {
        this.orderData = response;
        this.spinnerService.requestEnded();
      }, (err) => {
        console.log(err);
        this.spinnerService.requestEnded();
      });
  }

  changeOrder(v:any,from:any,to:any)
  {
    this.fromDate = from.value;
    this.toDate =to.value;
    
    if (this.fromDate != "" && this.toDate != "") {
      if (v == "desc") {
        this.callData(v, this.fromDate, this.toDate);
        this.order = "asc";
      }
      else {
        this.callData(v, this.fromDate, this.toDate);
        this.order = "desc";
      }
    }
    else {
      //console.log(v);
      if (v == "desc") {
        this.callData(v);
        this.order = "asc";
      }
      else {
        this.callData(v);
        this.order = "desc";
      }
    }
  }

  private callData(ord:string,from:string="",to="") {
    this.OrderListCount(from,to);
    this.orderService.getAllOrders(0, this.itemsDisplayPerPage, ord,from,to)
      .subscribe((response: any) => {
        this.orderData = response;
        this.spinnerService.requestEnded();
      }, (err) => {
        console.log(err);
        this.spinnerService.requestEnded();
      });
  }

  filterData(from:any,to:any)
  {
    try {
      this.spinnerService.requestStarted();
      this.fromDate = from.value;
      this.toDate = to.value;
      if (this.fromDate != "" && this.toDate != "") {
        if (this.fromDate <= this.toDate) {
          this.callData('desc',this.fromDate,this.toDate);
        }
      }
      else {
        this.callData('desc');
      }
    } catch (error) {
      console.log(error);
      this.spinnerService.requestEnded();
    }
  }

  reLoadPage()
  {
    window.location.reload();
  }

}
