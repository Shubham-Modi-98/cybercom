import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoaderService } from '../loader/loader.service';
import { CustomerService } from '../services/customer.service';
import { LoginCheckService } from '../services/login-check.service';


@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {

  customerData:any;
  totalLength!:number;
  page:number = 1;
  itemsDisplayPerPage:number = 5;
  searchData!:any;
  resultSearchData:any = [];
  txtSearchName!:any;
  encrypted:any = [];

  constructor(private customerService:CustomerService,
    private userCheckService:LoginCheckService,
    private router:Router,
    private spinnerService:LoaderService,
    ) {
      userCheckService.checkUser();
     }

  gotoAddCustomer()
  {
    this.router.navigateByUrl('/customers/add');
  }

  ngOnInit(): void {

    try {
      this.spinnerService.requestStarted();
      this.customerService.getAllCustomers()
        .subscribe((response: any) => {
          this.customerData = response;
          // Encryption - Method
          this.encryptionId(this.customerData);
          // console.log(this.customerData);
          this.spinnerService.requestEnded();
        }, (err) => {
          console.log(err);
          this.spinnerService.requestEnded();
        });
    
      this.CustomerListCounts();

      this.GetCustomerList();

    } catch (error) {
      console.log(error);
      this.spinnerService.resetSpinner();
    }

  }

  private GetCustomerList()
  {
    this.customerService.getCustomersList()
        .subscribe((response: any) => {
          this.searchData = response;
          this.spinnerService.requestEnded();
        }, (err) => {
          console.log(err);
          this.spinnerService.requestEnded();
        });
  }

  private CustomerListCounts()
  {
    this.customerService.getCustomersCount()
        .subscribe((response: any) => {
          this.totalLength = response;
          this.spinnerService.requestEnded();
        }, (err) => {
          console.log(err);
          this.spinnerService.requestEnded();
    });
  }

  searchCustRec(event:any) 
  {
    this.txtSearchName = event.target.value;
    this.resultSearchData = [];
    if(event.key == "Shift")
    {}
    else 
    {
      if(this.txtSearchName.length > 0) 
      {
        for (let search of this.searchData) {
          if(search.Name.toLowerCase().includes(this.txtSearchName.toLowerCase())) {
            this.resultSearchData.push(search);
          }
        }
        this.totalLength = this.resultSearchData.length;
        console.log(this.totalLength);
        this.encryptionId(this.resultSearchData);
        // console.log(this.resultSearchData);
      }
      else
      {
        this.CustomerListCounts();
      }
    }
  }

  pageNo(event:any)
  {
  
    this.spinnerService.requestStarted();
    this.page = event;

    let recSkip = (event-1) * this.itemsDisplayPerPage;
    //console.log(recSkip);
    this.customerService.getAllCustomers(recSkip,this.itemsDisplayPerPage)
      .subscribe((response:any) => {
        this.customerData = response;
        this.encryptionId(this.customerData);
        // console.log(this.customerData);
        this.spinnerService.requestEnded();
    },(err) => {
      console.log(err);
      this.spinnerService.requestEnded();
    });
  }

  private encryptionId(resourse:any)
  {
    for (let encyId of resourse) {
      encyId.CustomerID = window.btoa(encyId.CustomerID);
    } 
  }

}
