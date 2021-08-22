import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public accountService: AccountService, private router: Router) { }

  model: any = {}

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model).subscribe(data => {
      // this.router.navigateByUrl('/members');
    }, err => {
      console.log(err);
      // this.toastr.error(err.error);
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}
