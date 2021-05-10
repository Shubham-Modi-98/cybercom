import { LoginCheckService } from './../services/login-check.service';
import { CustomerService } from './../services/customer.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { timeout } from 'rxjs/operators';

@Component({
  selector: 'app-customer-delete',
  templateUrl: './customer-delete.component.html',
  styleUrls: ['./customer-delete.component.scss']
})
export class CustomerDeleteComponent implements OnInit {

  private cId!:number
  private cName!:any
  private routeParam!:any;

  constructor(private activeRoute:ActivatedRoute,
    private router:Router,
    private customerService:CustomerService,
    private checkUser:LoginCheckService
    ) { 
      checkUser.checkUser();
    }

  ngOnInit(): void {

    try {
      this.routeParam = this.activeRoute.snapshot.params;
      this.cId = Number(window.atob(this.routeParam['id']));
      
      Swal.fire({
        // position: 'top-end', 
        icon: 'warning',
        title: 'Customer Delete!',
        text: "Are you sure want to delete " + this.cName + " from Customers ?",
        showCancelButton: true,
        confirmButtonText: 'Yes,delete it!',
        cancelButtonText: 'No,keep it',
      }).then((result) => {
        if (result.isConfirmed) {
          this.customerService.deleteCustomer(this.cId)
            .subscribe(response => {
              Swal.fire(
                'Deleted!',
                'Customer Deleted :) ' + response,
                'success'
              ).then(result => {
                this.router.navigateByUrl('/customers');
              })
            }, (err) => {
                console.log(err);
                this.router.navigateByUrl('/customers');
            });
          // console.log(result.isConfirmed);
        }
        else {
          Swal.fire(
            'Cancelled',
            'Customer not deleted, Record is safe :)',
            'error'
          ).then(() => {
            this.router.navigateByUrl('/customers');
          })
        }
      });
    } catch (error) {
      console.log(error);
      this.router.navigateByUrl('/customers');
    }
  }

}
