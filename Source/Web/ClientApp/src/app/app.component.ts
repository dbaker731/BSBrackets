import { Component, OnInit } from '@angular/core';
import { UsersService } from './_services/users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'BS Brackets';
  users: any;

  constructor(private usersSerive: UsersService) {}

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.usersSerive.getUsers().subscribe( result => {
      this.users = result;
    }, err => {
      console.log(err);
    })
  }
}
