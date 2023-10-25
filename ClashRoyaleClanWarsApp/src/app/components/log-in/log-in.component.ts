import { Component, OnInit } from '@angular/core';
import { LogInService } from './log-in.service';
import { AuthService } from '../../services/auth.service';
import { TokenStorageService } from '../../services/token-storage.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss'],
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

    isSuccessful = false;
    isSignUpFailed = false;
    errorMessage = '';


    isLoggedIn = false;
    isLoginFailed = false;
  
    roles: string[] = [];

    constructor(public logInService: LogInService, public authService: AuthService, private tokenStorage: TokenStorageService){
      this.ImagePath = '/assets/pic.jpg'
    }
    ngOnInit(): void {
      if (this.tokenStorage.getToken()) {
        this.isLoggedIn = true;
        this.roles = this.tokenStorage.getUser().roles;
      }
    }

    LogIn(){
      

    this.authService.login(this.LogInForm.Username , this.LogInForm.Password).subscribe(
      data => {
        this.tokenStorage.saveToken(data.accessToken);
        this.tokenStorage.saveUser(data);

        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.roles = this.tokenStorage.getUser().roles;
        this.reloadPage();
      },
      err => {
        this.errorMessage = err.error.message;
        this.isLoginFailed = true;
      }
    );
    }
    
    SignUp(){
      if (this.SignUpForm.Password != this.SignUpForm.ConfirmPassword){
        alert("Passwords do not match");
        return;
      }
      
    
      // const x = this.authService.register(this.SignUpForm.Username , this.SignUpForm.Password, this.SignUpForm.ConfirmPassword);
      
      // sessionStorage.setItem('token', x.toString());

      this.authService.register(this.SignUpForm.Username , this.SignUpForm.Password, this.SignUpForm.ConfirmPassword).subscribe(
        data => {
          this.isSuccessful = true;
          sessionStorage.setItem('token', "ok");

          this.isSignUpFailed = false;
        },
        err => {
          this.errorMessage = err.error.message;
          this.isSignUpFailed = true;
          sessionStorage.setItem('error', err.error.message);
        }
      );
      
    }

    reloadPage(): void {
      window.location.reload();
    }
  }
  