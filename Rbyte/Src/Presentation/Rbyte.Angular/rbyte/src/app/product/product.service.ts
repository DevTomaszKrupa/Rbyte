import { Product } from './models/product';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient: HttpClient) { }

  getProductList(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(
      environment.apiAddress + `products`
    );
  }

  add(model: Product): Observable<any> {
    return this.httpClient.post<Product>(
      environment.apiAddress + `products`,
      model
    );
  }
}
