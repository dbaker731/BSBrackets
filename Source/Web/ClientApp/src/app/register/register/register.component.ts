import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister: EventEmitter<boolean> = new EventEmitter();
  registerModel: any = {}

  constructor(
    private accountService: AccountService,
    private toastrService: ToastrService
    ) { }

  ngOnInit(): void {
  }

  register() {
    console.log(this.registerModel);
    this.accountService.register(this.registerModel).subscribe(result => {
      
      this.cancel();
    }, err => {
      console.log(err);
      this.toastrService.error(err.error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
