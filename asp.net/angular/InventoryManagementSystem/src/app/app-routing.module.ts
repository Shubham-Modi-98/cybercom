import { CustomerDeleteComponent } from './customer-delete/customer-delete.component';
import { OrdersComponent } from './orders/orders.component';
import { ProductDeleteComponent } from './product-delete/product-delete.component';
import { ProductAddEditComponent } from './product-add-edit/product-add-edit.component';
import { LogoutComponent } from './logout/logout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './customers/customers.component';
import { CustomerAddEditComponent } from './customer-add-edit/customer-add-edit.component';
import { ProductsComponent } from './products/products.component';

const routes: Routes = [
  // Login-Logout-Dashboard Routes
  {path:'', component:LoginComponent},
  {path:'dashboard', component:DashboardComponent},
  {path:'logout', component:LogoutComponent},
  
  // Customers CRUD Routes
  {path:'customers', component:CustomersComponent},
  {path:'customers/add', component:CustomerAddEditComponent},
  {path:'customers/edit/:id', component:CustomerAddEditComponent},
  {path:'customers/delete/:id/:name', component:CustomerDeleteComponent},
  
  // Products CRUD Routes
  {path:'products', component:ProductsComponent},
  {path:'products/add', component:ProductAddEditComponent},
  {path:'products/edit/:id', component:ProductAddEditComponent},
  {path:'products/delete/:id/:name', component:ProductDeleteComponent},
  
  // Orders Routes
  {path:'orders', component:OrdersComponent}, 

  // Anonymous Routes
  {path:'**', component:LogoutComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
