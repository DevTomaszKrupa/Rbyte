import { ProductService } from './../product.service';
import { RouterModule } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../models/product';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent {
  @Input() items: Product[] = [];
  constructor(private routerModule: RouterModule,
    private productService: ProductService) { }
}
