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
      const { username, password } = this.LogInForm;

    this.authService.login(username, password).subscribe(
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
      const { username, password, pass1 } = this.SignUpForm;
    
    
      this.authService.register(username, password).subscribe(
        data => {
          console.log(data);
          this.isSuccessful = true;
          this.isSignUpFailed = false;
        },
        err => {
          this.errorMessage = err.error.message;
          this.isSignUpFailed = true;
        }
      );
      
    }

    reloadPage(): void {
      window.location.reload();
    }
  }
  