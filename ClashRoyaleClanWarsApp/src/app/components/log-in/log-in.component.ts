import { Component, OnInit } from '@angular/core';
import { LogInService } from './log-in.service';
import { AuthService } from '../../services/auth.service';
import { TokenStorageService } from '../../services/token-storage.service';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';

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

        this.tokenStorage.saveToken(data.token);
        var decoded = atob(data.token.split('.')[1])


        //"{\"http://schemas.microsoft.com/ws/2008/06/identity/claims/role\":\"User\",\"jti\":\"c4aae3e0-f56f-40f3-ab5b-a0b54a20e938\",\"iat\":\"31-Oct-23 5:24:20 AM\",\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":\"b3ff34d2-8d42-4094-bdf1-7416519d43cf\",\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name\":\"pp11\",\"exp\":1698733460}"

        var dec_s = decoded.split(',')
        this.tokenStorage.saveUser(dec_s[4]);
        this.tokenStorage.saveRoles(dec_s[0]);
        this.tokenStorage.expToken(dec_s[2]);
        this.tokenStorage.saveExp(dec_s[5]);

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
