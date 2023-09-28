import { Component, OnInit } from '@angular/core';
import { LogInService } from './log-in.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss'],
  providers: [LogInService],
})
export class LogInComponent implements OnInit {
    ImagePath: string;

    LogInForm: any = {
      Username: '',
      Password: '',
    };

    SignUpForm: any = {
      Username: '',
      Password: '',
      ConfirmPassword: '',
    };

    constructor(){
      this.ImagePath = '/assets/pic.jpg'
    }
    ngOnInit(): void {
        
    }

    LogIn(){
      console.log(this.LogInForm);
    }

    SignUp(){
      if (this.SignUpForm.Password != this.SignUpForm.ConfirmPassword){
        alert("Passwords do not match");
        return;
      }
      console.log(this.SignUpForm);
    }
}
