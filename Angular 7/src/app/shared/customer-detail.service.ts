import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Customer } from './customer-detail.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  formData: Customer= {
    Id :null,
    FullName: null,
    AccountType: null,
    Amount: null,
  };
  
  readonly rootURL = 'http://localhost:54277/api';
  list : Customer[];

  constructor(private http: HttpClient) { }

  postCustomer() {
    return this.http.post(this.rootURL + '/Customer', this.formData);
    console.log(this.formData);
  }
  putCustomer() {
    return this.http.put(this.rootURL + '/Customer/'+ this.formData.Id, this.formData);
  }
  deleteCustomer(id) {
    return this.http.delete(this.rootURL + '/Customer/'+ id);
  }

  refreshList(){
    this.http.get(this.rootURL + '/Customer')
    .toPromise()
    .then(res => this.list = res as Customer[]);
    console.log(this.list);
    
  }
}
