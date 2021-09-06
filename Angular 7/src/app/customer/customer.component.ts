import { HttpClient } from '@angular/common/http';
import { Customer } from './../shared/customer-detail.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerService } from './../shared/customer-detail.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: []
})
export class CustomerComponent implements OnInit {

  constructor(private router: Router,private service:CustomerService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(pd: Customer) {
    this.service.formData = Object.assign({}, pd);
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
}
