import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessionModel } from '../../models/session.model';
import { AuthService } from '../../services/auth.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {
  public model: any = {};
  public errorMessage: string;
  constructor(private router: Router, private userService: UserService, private authService: AuthService) {}

  ngOnInit() {
    sessionStorage.removeItem("UserName");
    sessionStorage.clear();
  }
  public login() {
    this.userService.login(this.model).subscribe(value => {
      if (value.success) {
        const session = new SessionModel();
        session.token = value.data;
        this.userService.getUserByUsername(this.model.username).subscribe(value => {
          if (value.success) {
            session.user = value.data;
            this.authService.setCurrentSession(session);
            //console.log(value.data);
          } else {
            console.log(value.errorMessage);
          }
        }, error => console.error(error));
        this.router.navigate(['/movie']);
      } else {
        this.errorMessage = value.errorMessage;
      }
    }, error => this.errorMessage = error.message);
  }
}
