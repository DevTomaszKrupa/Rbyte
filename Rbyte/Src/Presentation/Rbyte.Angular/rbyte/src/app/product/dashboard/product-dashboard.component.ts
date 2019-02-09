import { ProductService } from './../product.service';
import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';

@Component({
  selector: 'app-product-dashboard',
  templateUrl: './product-dashboard.component.html',
  styleUrls: ['./product-dashboard.component.scss']
})
export class ProductDashboardComponent implements OnInit {
  public products: Product[] = [];
  constructor(private productService: ProductService) { }

  ngOnInit = async () => {
    this.products = await this.productService.getCollection();
  }

}
