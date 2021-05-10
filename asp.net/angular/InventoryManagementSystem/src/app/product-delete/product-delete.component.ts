import { ProductService } from './../services/product.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { LoginCheckService } from '../services/login-check.service';

@Component({
  selector: 'app-product-delete',
  templateUrl: './product-delete.component.html',
  styleUrls: ['./product-delete.component.scss']
})
export class ProductDeleteComponent implements OnInit {
  
  // private pId!:any
  // private pName!:any
  private routeParam!:any;

  constructor(private activeRoute:ActivatedRoute,
    private router:Router,
    private productService:ProductService,
    private checkUser:LoginCheckService,
    ) { 
      checkUser.checkUser();
    }

  ngOnInit(): void {
    try {
      this.routeParam = this.activeRoute.snapshot.params;
      let pId = Number(window.atob(this.routeParam['id']));
      let pName = String(this.routeParam['name']);

      Swal.fire({
        // position: 'top-end', 
        icon: 'warning',
        title: 'Customer Delete!',
        text: "Are you sure want to delete " + pName + " from Customers ?",
        showCancelButton: true,
        confirmButtonText: 'Yes,delete it!',
        cancelButtonText: 'No,keep it',
      }).then((result) => {
        if (result.isConfirmed) {
          let decyId: number = Number(pId);
          console.log(decyId);
          this.productService.deleteProduct(decyId)
            .subscribe(response => {
              Swal.fire(
                'Deleted!',
                'Customer Deleted Successfully. :) ',
                'success',
              )
              this.router.navigateByUrl('/products');
            }, (err) => {
              console.log(err);
              this.router.navigateByUrl('/products');
            });
          // console.log(result.isConfirmed);
        }
        else {
          Swal.fire(
            'Cancelled',
            'Customer not deleted, Record is safe :)',
            'error'
          )
          this.router.navigateByUrl('/products');
        }
      });
    } catch (error) {
      console.log(error);
      this.router.navigateByUrl('/products');
    }
  }

}
