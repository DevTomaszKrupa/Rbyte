import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductModule } from './product/product.module';
import { LayoutModule } from './layout/layout.module';
import { CategoryModule } from './category/category.module';
import { DiscountModule } from './discount/discount.module';
import { StorehouseModule } from './storehouse/storehouse.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    LayoutModule,
    ProductModule,
    CategoryModule,
    DiscountModule,
    StorehouseModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
