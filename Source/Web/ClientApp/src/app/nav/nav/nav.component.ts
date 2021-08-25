import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
    ) { }

  loginModel: any = {}

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.loginModel).subscribe(result => {
      this.router.navigateByUrl('/brackets');
    }, err => {
      this.toastr.error(err.error);
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}
