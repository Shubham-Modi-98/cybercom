import { LoaderService } from './../loader/loader.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { NotFoundError } from '../not-found-error';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private url = "https://localhost:44302/api/customers";
  // private urlGetList = "https://localhost:44302/api/dashboard/allcustomers"
  constructor(private http:HttpClient,
    private spinnerService:LoaderService,
    ) { }

    getCustomersList() {
      return this.http.get(this.url + "/allcustomers")
        .pipe(
          map(response => response),
          catchError(this.handleError));
    }

    getAllCustomers(recSkip:number=0,recTake?:number) {
      return this.http.get(this.url + "/getcustomers?recordSkip="+recSkip+"&recordTake="+recTake)
        .pipe(
          map(response => response),
          catchError(this.handleError));
    }

    getCustomersCount() {
      return this.http.get(this.url+"/totalcustomers")
        .pipe(
          map(response => response),
          catchError(this.handleError));
    }

    createCustomer(data:any) {
    return this.http.post(this.url+"/addcustomer",data)
      .pipe(
        map(response => response),
        catchError(this.handleError));
    }

    getCustomerById(id:number) {
    return this.http.get(this.url+'/getcustomerbyid/'+id)
    .pipe(
      map(response => response),
      catchError(this.handleError));
    }

    updateCustomer(id:number,data:any) {
    return this.http.put(this.url+'/updatecustomer/'+id,data)
    .pipe(
      map(response => response),
      catchError(this.handleError));
    }

    deleteCustomer(id:number) {
    return this.http.delete(this.url+'/deletecustomer/'+id)
    .pipe(
      map(response => response),
      catchError(this.handleError));
    }

    handleError(error:any) {
      console.log(error.message);
      this.spinnerService.resetSpinner();
      // return throwError (error.message || 'Server Error' );
      return Observable.throw(new NotFoundError());
    }

}
