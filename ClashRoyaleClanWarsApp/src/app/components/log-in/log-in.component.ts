import { Component, OnInit } from '@angular/core';
import { LogInService } from './log-in.service';
import { AuthService } from '../../services/auth.service';
import { TokenStorageService } from '../../services/token-storage.service';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode"

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss'],
  providers: [MessageService]
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

  constructor(public logInService: LogInService, public authService: AuthService, private tokenStorage: TokenStorageService, private messageService: MessageService, private router: Router) {
    this.ImagePath = '/assets/pic.jpg'
  }
  ngOnInit(): void {
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
      this.roles = this.tokenStorage.getUser().roles;
    }
  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms))

  }
  LogIn() {

    this.authService.login(this.LogInForm.Username, this.LogInForm.Password).subscribe(
      async data => {

        const jwt = jwt_decode.jwtDecode(data.token)
        var decoded = atob(data.token.split('.')[1])
        var dec_s = decoded.split(',')


        this.tokenStorage.expToken(jwt.exp!);
        this.tokenStorage.saveToken(jwt.jti!);
        this.tokenStorage.saveUser( dec_s[4] );

        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'You have been logged in' });

        await this.delay(2000)

        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.roles = this.tokenStorage.getUser().roles;


        this.router.navigate(['/'])
          .then(() => {
            window.location.reload();
          });
      },
      err => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Please check the data' });

        this.isLoginFailed = true;
      }
    );
  }

  SignUp() {

    this.authService.register(this.SignUpForm.Username, this.SignUpForm.Password, this.SignUpForm.ConfirmPassword).subscribe(
      {
        next: (data) => {
          this.isSuccessful = true;
          this.isSignUpFailed = false;
          this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Your account is created' });

        },
        error: (err) => {
          console.log(err)
          this.errorMessage = err.error.message;
          this.isSignUpFailed = true;
          sessionStorage.setItem('error', err.error);

          if (err.error == "[object Object]"){
            this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Your account is created' });

          }
          else
          this.messageService.add({ severity: 'error', summary: 'Error', detail: err.error.message });

        }
      }
    );

  }

  reloadPage(): void {
    window.location.reload();
  }
}
