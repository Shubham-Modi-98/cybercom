import { ProductService } from './../services/product.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginCheckService } from '../services/login-check.service';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { LoaderService } from '../loader/loader.service';

@Component({
  selector: 'app-product-add-edit',
  templateUrl: './product-add-edit.component.html',
  styleUrls: ['./product-add-edit.component.scss']
})
export class ProductAddEditComponent implements OnInit {

  productForm!:FormGroup;
  btnText:string = 'Add Product'; 
  headingText:string = ''; 
  private stockPattern:any = /^\d*[1-9]\d*$/;
  private pricePattern:any = /^[+]?([0-9]+(?:[\.][0-9]*)?|\.[0-9]+)$/;
  private routePath!:any;
  private routeParam!:any;

  constructor(private formBuilder:FormBuilder,
    private userCheckService:LoginCheckService,
    private productService:ProductService,
    private activeRouute:ActivatedRoute,
    private router:Router,
    private spinnerService:LoaderService,
  ) {
    userCheckService.checkUser();
   }

  ngOnInit(): void {
    try {
      this.IntializedForm();
      this.routePath = this.activeRouute.snapshot.routeConfig?.path;
      this.routeParam = this.activeRouute.snapshot.params;

      if (this.routePath == "products/add") {
        this.btnText = "Add Product";
        this.headingText = "Add Product";
      }
      if (this.routePath == "products/edit/:id") {
        this.btnText = "Update Product";
        this.headingText = "Edit Product";
        if (this.routeParam['id'] == null) {
          this.errorSwal();
          console.log("Invalid param id- " + this.routeParam['id']);
        }
        else {
          this.spinnerService.requestStarted();
          let decyId: number = Number(window.atob(this.routeParam['id']));
          this.productService.getProductById(decyId)
            .subscribe((response: any) => {
              this._form.Name.setValue(response.Name);
              this._form.Stock.setValue(response.Stock);
              this._form.Price.setValue(response.Price);
              this.spinnerService.requestEnded();
            }, (err) => {
              this.spinnerService.resetSpinner();
              this.errorSwal(err);
              console.log(err);
            });
        }
      }
    } catch (error) {
      console.log(error);
      this.spinnerService.resetSpinner();
    }
  }

  get _form() {
    return this.productForm.controls;
  }

  IntializedForm()
  {
    this.productForm = this.formBuilder.group({
      Name: ['',[Validators.required,
        Validators.minLength(5),
        Validators.maxLength(30),
      ]],
      Stock: ['',[Validators.required,
        Validators.pattern(this.stockPattern),
      ]],
      Price: ['',[Validators.required,
        Validators.pattern(this.pricePattern),
      ]],
    });
  }

  addProduct(formData:any)
  {
    try {
      this.spinnerService.requestStarted();
      if (this.routePath == "products/add") {
        console.log(formData.value);

        this.productService.createProduct(formData.value)
          .subscribe(response => {
            this.spinnerService.requestEnded();
            this.successSwal('Product Added Successfully :)', this.router.navigateByUrl('/products'));
          }, (err) => {
            this.spinnerService.resetSpinner();
            this.errorSwal(err);
            console.log(err);
          });
      }
      else if (this.routePath == "products/edit/:id") {
        if (this.routeParam['id'] != null && this.routeParam['id'] != "") {
          let decyId: number = Number(window.atob(this.routeParam['id']));
          this.productService.updateProduct(decyId, formData.value)
            .subscribe(response => {
              this.spinnerService.requestEnded();
              this.successSwal('Product Updated Successfully :)', this.router.navigateByUrl('/products'));
            }, (err) => {
              this.spinnerService.resetSpinner();
              this.errorSwal(err);
              console.log(err);
            });
        }
        else {
          this.spinnerService.requestEnded();
          this.errorSwal();
        }
      }
    } catch (error) {
      this.spinnerService.resetSpinner();
      console.log(error);
    }
    
  }
  
  successSwal(msg:string, path?:any)
  {
    Swal.fire({  
      // position: 'top-end', 
      icon: 'success',  
      title: 'Customers',  
      text:  msg,  
      showConfirmButton: true,  
      timer: 3500,
    }).then((result) => {
      if(path != null) {
        path;
      }
    });

    // Swal.fire({  
      // position: 'top', 
      // icon: 'success',  
      // title: 'Customer Added Successfully',  
      // showConfirmButton: true,  
      // timer: 2500  
    // })
  }

  errorSwal(err?:any)
  {
    Swal.fire({  
      icon: 'error',  
      title: 'Oops...',  
      text: 'Something went wrong!,TryAgain!! ' + err!,  
      showConfirmButton: true,
      confirmButtonText: "Ok",
      timer: 5000,
    }).then((resuslt) => {
      this.router.navigateByUrl('/products/add');
    });
  }

}
