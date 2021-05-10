import { LoaderService } from './../loader/loader.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm!:FormGroup;
  private adminCred:any;
  private admin:any;

  constructor(private formBuilder:FormBuilder,
    private router:Router,
    private spinnerService: LoaderService,
    ) { }

  ngOnInit(): void {
    this.InitializedForm();
  }

  InitializedForm()
  {
    this.loginForm = this.formBuilder.group({
      UserName: ['',Validators.required],
      Password:['',Validators.required],
    })
  }

  get _form() {
    return this.loginForm.controls;
  }
  
  checkAdmin(formData:any)
  {
    this.spinnerService.requestStarted();
    if(formData.value.UserName === "Admin@user.com" && formData.value.Password === "Admin@12345")
    {
      this.spinnerService.requestEnded();
      this.adminCred = {'userName':formData.value.UserName,'password':formData.value.Password};
      sessionStorage.setItem('userCred',JSON.stringify(this.adminCred));
      this.router.navigateByUrl('/dashboard');
      // this.admin = sessionStorage.getItem('userCred');
      // console.log(JSON.parse(this.admin));
    }
    else {
      setTimeout(() => {
        this.spinnerService.requestEnded();
        console.log("hide");
        this.loginForm.setErrors({
          loginError: true,
        });
      },2000);
      
    }
    
  }
}
