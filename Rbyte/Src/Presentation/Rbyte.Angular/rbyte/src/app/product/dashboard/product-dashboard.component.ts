import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';

@Component({
  selector: 'app-product-dashboard',
  templateUrl: './product-dashboard.component.html',
  styleUrls: ['./product-dashboard.component.scss']
})
export class ProductDashboardComponent implements OnInit {
  public products: Product[] = [];
  constructor() { }

  ngOnInit() {
    this.products.push(new Product(1, 'Mąka', '100% gluten', 1231232, 15, 2.32, 3.99));
    this.products.push(new Product(1, 'Mąka', '100% gluten', 1231232, 15, 2.32, 3.99));
    this.products.push(new Product(1, 'Mąka', '100% gluten', 1231232, 15, 2.32, 3.99));
    this.products.push(new Product(1, 'Mąka', '100% gluten', 1231232, 15, 2.32, 3.99));
    this.products.push(new Product(1, 'Mąka', '100% gluten', 1231232, 15, 2.32, 3.99));
    this.products.push(new Product(1, 'Mąka', '100% gluten', 1231232, 15, 2.32, 3.99));
    this.products.push(new Product(1, 'Mąka', '100% gluten', 1231232, 15, 2.32, 3.99));
  }

}
