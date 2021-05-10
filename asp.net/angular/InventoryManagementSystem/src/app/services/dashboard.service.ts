import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { NotFoundError } from '../not-found-error';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  private url = "https://localhost:44302/api/dashboard";
  
  constructor(private http:HttpClient,
    ) { }

    getTodaysOrders() {
    return this.http.get(this.url + "/todaysordercounts")
      .pipe(
        map(response => response),
        catchError(this.handleError));
  }

  getAvailableProducts() {
    return this.http.get(this.url + "/availableproductcounts")
      .pipe(
        map(response => response),
        catchError(this.handleError));
  }

  getLessProducts() {
    return this.http.get(this.url + "/lessproductcounts")
      .pipe(
        map(response => response),
        catchError(this.handleError));
  }

  handleError(error:any) {
    console.log(error.message);
    // return throwError (error.message || 'Server Error' );
    return Observable.throw(new NotFoundError());
  }

}
