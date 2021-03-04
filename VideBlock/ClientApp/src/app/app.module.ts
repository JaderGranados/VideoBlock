import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './views/home/home.component';
import { CounterComponent } from './views/counter/counter.component';
import { FetchDataComponent } from './views/fetch-data/fetch-data.component';
import { MovieComponent } from './views/movie/movie.component';
import { TableComponent } from './components/table/table.component';
import { MovieService } from './services/movie.service';
import { UserService } from './services/user.service';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { UserRegisterComponent } from './views/user-register/user-register.component';
import { MovieCreateComponent } from './views/movie-create/movie-create.component';
import { ErrorMessageComponent } from './components/error-message/error-message.component';
import { AuthService } from './services/auth.service';
import { PersonaService } from './services/persona.service';
import { FormMovieComponent } from './components/form-movie/form-movie.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MovieComponent,
    TableComponent,
    UserRegisterComponent,
    ErrorMessageComponent,
    MovieCreateComponent,
    FormMovieComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'movie', component: MovieComponent },
      { path: 'user-register', component: UserRegisterComponent },
      { path: 'movie-create', component: MovieCreateComponent }
    ])
  ],
  providers: [
    MovieService,
    UserService,
    AuthService,
    PersonaService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
