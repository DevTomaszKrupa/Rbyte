import { Product } from './models/product';
import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService implements OnInit {

  apiAddress: string;

  ngOnInit(): void {
    this.apiAddress = environment.apiAddress;
  }


  constructor(private httpClient: HttpClient) { }

  getCollection = (): Promise<Product[]> =>
    this.httpClient.get<Product[]>(this.apiAddress + `product`).toPromise()

  create = (model: Product): Promise<any> => // TODO Remove 'any'
    this.httpClient.post<Product>(this.apiAddress + `product`, model).toPromise()

}
