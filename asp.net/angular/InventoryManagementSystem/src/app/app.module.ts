import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from  '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LogoutComponent } from './logout/logout.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerAddEditComponent } from './customer-add-edit/customer-add-edit.component';
import { CustomerDeleteComponent } from './customer-delete/customer-delete.component';
import { ProductsComponent } from './products/products.component';
import { ProductAddEditComponent } from './product-add-edit/product-add-edit.component';
import { LoaderComponent } from './loader/loader/loader.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OrdersComponent } from './orders/orders.component';
import { ProductDeleteComponent } from './product-delete/product-delete.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    DashboardComponent,
    LogoutComponent,
    CustomersComponent,
    CustomerAddEditComponent,
    CustomerDeleteComponent,
    ProductsComponent,
    ProductAddEditComponent,
    LoaderComponent,
    OrdersComponent,
    ProductDeleteComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    NgxPaginationModule,
    NgbModule,
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
