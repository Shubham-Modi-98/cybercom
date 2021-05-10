import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { LoaderService } from '../loader/loader.service';
import { NotFoundError } from '../not-found-error';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private url = "https://localhost:44302/api/orders";

  constructor(private http:HttpClient,
    private spinnerService:LoaderService,
    ) { }

    getAllOrders(recSkip:number=0,recTake:number = 5,order?:string,fromDate:string="",toDate:string="") {
      return this.http.get(this.url + "/getorders?recordSkip="+recSkip+"&recordTake="+recTake +"&ord="+order+"&fromDate="+fromDate+"&toDate="+toDate)
        .pipe(
          map(response => response),
          catchError(this.handleError));
    }

    getOrdersCount(fromDate:string="", toDate:string="") {
      return this.http.get(this.url+"/gettotalorders?fromDate="+ fromDate +"&toDate="+ toDate)
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
