import { StorehouseDashboardComponent } from './storehouse/storehouse-dashboard/storehouse-dashboard.component';
import { DiscountDashboardComponent } from './discount/discount-dashboard/discount-dashboard.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductDashboardComponent } from './product/dashboard/product-dashboard.component';
import { CategoryDashboardComponent } from './category/category-dashboard/category-dashboard.component';
import { ProductCreateComponent } from './product/create/product-create.component';

export const routes: Routes = [
  { path: 'products', component: ProductDashboardComponent },
  { path: 'products/create', component: ProductCreateComponent },
  { path: 'categories', component: CategoryDashboardComponent },
  { path: 'discounts', component: DiscountDashboardComponent },
  { path: 'storehouses', component: StorehouseDashboardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
