import { LoaderService } from './../loader/loader.service';
import { CustomerService } from './../services/customer.service';
import { LoginCheckService } from './../services/login-check.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-customer-add-edit',
  templateUrl: './customer-add-edit.component.html',
  styleUrls: ['./customer-add-edit.component.scss']
})
export class CustomerAddEditComponent implements OnInit {

  customerForm!:FormGroup;
  btnText:string = 'Add Customer'; 
  headingText:string = ''; 
  private emailPattern = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/;
  private phonePattern = /^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/;
  // /^[+]*[(]{0,1}[0-9]{1,3}[)]{0,1}[-\s\./0-9]*$/g;
  private namePattern = /^[a-zA-Z ]*$/; //^[A-Za-z]+$/;
  private routePath!:any;
  private routeParam!:any;

  constructor(private formBuilder:FormBuilder,
      private userCheckService:LoginCheckService,
      private customerService:CustomerService,
      private activeRoute:ActivatedRoute,
      private router:Router,
      private spinnerService:LoaderService,
    ) {
      userCheckService.checkUser();
     }

  ngOnInit(): void {
    try {
      this.IntializedForm();
      this.routePath = this.activeRoute.snapshot.routeConfig?.path;
      this.routeParam = this.activeRoute.snapshot.params;
      // console.log(this.routePath);
      // console.log(this.routeParam);

      if (this.routePath == "customers/add") {
        //console.log("true /add");
        this.btnText = "Add Customer";
        this.headingText = "Add Customer";
      }
      if (this.routePath == "customers/edit/:id") {
        //console.log("true /edit");
        // console.log(this.routeParam['id']);
        this.btnText = "Update Customer";
        this.headingText = "Edit Customer";
        if (this.routeParam['id'] == null) {
          this.errorSwal();
          console.log("Invalid param id- " + this.routeParam['id']);
        }
        else {
          this.spinnerService.requestStarted();
          let decyId: number = Number(window.atob(this.routeParam['id']));
          this.customerService.getCustomerById(decyId)
            .subscribe((response: any) => {
              this._form.Name.setValue(response.Name);
              this._form.Email.setValue(response.Email);
              this._form.Phone.setValue(response.Phone);
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
    }
  }

  IntializedForm()
  {
    this.customerForm = this.formBuilder.group({
      Name: ['',[Validators.required,
        Validators.minLength(3),
        Validators.maxLength(20),
        Validators.pattern(this.namePattern),
      ]],
      Email: ['',[Validators.required,
        Validators.pattern(this.emailPattern),
      ]],
      Phone: ['',[Validators.required,
        Validators.minLength(10),
        Validators.maxLength(11),
        Validators.pattern(this.phonePattern),
      ]],
    });
  }

  get _form() {
    return this.customerForm.controls;
  }

  addCustomer(formData: any) 
  {
    try {
      this.spinnerService.requestStarted();
      if (this.routePath == "customers/add") {
        console.log(formData.value);

        this.customerService.createCustomer(formData.value)
          .subscribe(response => {
            this.spinnerService.requestEnded();
            this.successSwal('Customer Added Successfully :)', this.router.navigateByUrl('/customers'));
          }, (err) => {
            this.spinnerService.resetSpinner();
            this.errorSwal(err);
            console.log(err);
          });
      }
      else if (this.routePath == "customers/edit/:id") {
        if (this.routeParam['id'] != null && this.routeParam['id'] != "") {
          let decyId: number = Number(window.atob(this.routeParam['id']));
          this.customerService.updateCustomer(decyId, formData.value)
            .subscribe(response => {
              this.spinnerService.requestEnded();
              this.successSwal('Customer Updated Successfully :)', this.router.navigateByUrl('/customers'));
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
      console.log(error);
      this.spinnerService.resetSpinner();
    }

  }

  successSwal(msg:string,path?:any)
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
      this.router.navigateByUrl('/customers/add');
    });
  }

}
