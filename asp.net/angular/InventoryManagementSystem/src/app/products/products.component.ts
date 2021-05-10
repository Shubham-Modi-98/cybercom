import { ProductService } from './../services/product.service';
import { Component, OnInit } from '@angular/core';
import { LoginCheckService } from '../services/login-check.service';
import { Router } from '@angular/router';
import { LoaderService } from '../loader/loader.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  productData!:any;
  totalLength!:number;
  page:number = 1;
  itemsDisplayPerPage:number = 5;
  searchData!:any;
  resultSearchData:any = [];
  txtSearchName!:any;

  constructor(private productService:ProductService,
    private userCheckService:LoginCheckService,
    private router:Router,
    private spinnerService:LoaderService,
    ) {
      userCheckService.checkUser();
     }

  ngOnInit(): void {
    
    try {
      this.spinnerService.requestStarted();

      this.productService.getAllProducts()
        .subscribe((response: any) => {
          this.productData = response;
          this.encryptionId(this.productData);
          this.spinnerService.requestEnded();
        }, (err) => {
          console.log(err);
          this.spinnerService.requestEnded();
        });

      this.ProductListCount();

      this.GetProductList();
      
    } catch (error) {
      console.log(error);
      this.spinnerService.resetSpinner();
    }

  }

  private ProductListCount()
  {
    this.productService.getProductsCount()
        .subscribe((response: any) => {
          this.totalLength = response;
          this.spinnerService.requestEnded();
        }, (err) => {
          console.log(err);
          this.spinnerService.requestEnded();
        });
  }

  private GetProductList()
  {
    this.productService.getProductsList()
        .subscribe((response: any) => {
          this.searchData = response;
          this.encryptionId(this.searchData);
          this.spinnerService.requestEnded();
        }, (err) => {
          console.log(err);
          this.spinnerService.requestEnded();
        });
  }

  gotoAddProduct() {
    this.router.navigateByUrl('/products/add');
  }

  searchProdRec(event:any) 
  {
    this.txtSearchName = event.target.value;
    this.resultSearchData = [];
    if(event.key == "Shift") { }
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
        this.encryptionId(this.resultSearchData);
      }
      else {
        this.ProductListCount();
      }
    }
  }

  pageNo(event:any)
  {

    // console.log(event);
    // console.log(this.itemsDisplayPerPage * (event - 1));
    // console.log(this.page);
    
    this.spinnerService.requestStarted();
    this.page = event;

    let recSkip = (event-1) * this.itemsDisplayPerPage;
    //console.log(recSkip);
    this.productService.getAllProducts(recSkip,this.itemsDisplayPerPage)
      .subscribe((response:any) => {
        this.productData = response;
        this.encryptionId(this.productData);
        this.spinnerService.requestEnded();
    },(err) => {
      console.log(err);
      this.spinnerService.requestEnded();
    });
  }

  private encryptionId(resourse:any)
  {
    for (let encyId of resourse) {
      encyId.ProductID = window.btoa(encyId.ProductID);
    } 
  }

}
