import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html'
})

export class UserRegisterComponent implements OnInit {
  public data: boolean = false;
  public userForm: FormGroup;
  public errorMessage: string;
  public isAuthenticated: boolean;

  constructor(private formBuilder: FormBuilder, private userService: UserService, private router: Router, authService: AuthService) {
    this.isAuthenticated = authService.isAuthenticated();
  }

  ngOnInit() {
    this.userForm = this.formBuilder.group({
      userName: ['', [Validators.required, Validators.maxLength(250)]],
      name: ['', [Validators.required, Validators.maxLength(250)]],
      password: ['', [Validators.required, Validators.maxLength(250)]],
      lastName: ['', [Validators.required, Validators.maxLength(250)]]
    });
  }

  public onFormSubmit() {
    if (this.userForm.valid) {
      const user = this.userForm.value;
      //console.log(user);
      this.userService.saveUser(user).subscribe(value => {
        if (value.success) {
          this.router.navigate(['']);
        } else {
          this.errorMessage = value.errorMessage;
        }
      }, error => this.errorMessage = error.message);
    } else {
      this.errorMessage = "Errores de validación";
    }
  }
}
