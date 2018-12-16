import { ProductService } from './../product.service';
import { Product } from './../models/product';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.scss']
})
export class ProductCreateComponent implements OnInit {
  product: Product = new Product(0, '', '', undefined, undefined, undefined, undefined);

  constructor(private productService: ProductService) { }

  ngOnInit() {
  }

  submitHandler(): void {
    this.productService.add(this.product).subscribe(x => console.log(x));
  }
}
