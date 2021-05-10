import { LoaderService } from './../loader/loader.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs/operators';
import { NotFoundError } from '../not-found-error';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private url = "https://localhost:44302/api/products";
  // private urlGetList = "https://localhost:44302/api/dashboard/allproducts"

  constructor(private http:HttpClient,
    private spinnerService:LoaderService,
    ) { }

    getProductsList() {
      return this.http.get(this.url + "/allproducts")
        .pipe(
          map(response => response),
          catchError(this.handleError));
    }

    getAllProducts(recSkip:number=0,recTake:number = 5) {
      return this.http.get(this.url + "/getproducts?recordSkip="+recSkip+"&recordTake="+recTake)
        .pipe(
          map(response => response),
          catchError(this.handleError));
    }
  
    getProductsCount() {
      return this.http.get(this.url+"/gettotalproducts")
        .pipe(
          map(response => response),
          catchError(this.handleError));
    }
  
    createProduct(data:any) {
      return this.http.post(this.url + "/addproducts",data)
        .pipe(
          map(response => response),
          catchError(this.handleError));
    }
  
    getProductById(id:number) {
      return this.http.get(this.url+'/getproductsbyid/'+id)
      .pipe(
        map(response => response),
        catchError(this.handleError));
    }
  
    updateProduct(id:number,data:any) {
      return this.http.put(this.url+'/updateproduct/'+id,data)
      .pipe(
        map(response => response),
        catchError(this.handleError));
    }
  
    deleteProduct(id:number) {
      return this.http.delete(this.url+'/deleteproduct/'+id)
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
