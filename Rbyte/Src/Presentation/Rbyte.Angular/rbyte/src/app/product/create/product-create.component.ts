import { ProductService } from './../product.service';
import { Product } from './../models/product';
import { Component } from '@angular/core';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.scss']
})
export class ProductCreateComponent {
  product: Product = new Product(0, '', '', undefined, undefined, undefined, undefined);

  constructor(private productService: ProductService) { }

  submitHandler(): void {
    this.productService.create(this.product);
  }
}
