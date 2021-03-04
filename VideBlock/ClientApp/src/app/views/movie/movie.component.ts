import { Component } from "@angular/core";
import { Observable } from "rxjs";
import { MovieInterface } from "../../interfaces/movie.interface";
import { ButtonModel } from "../../models/button.model";
import { AuthService } from "../../services/auth.service";
import { MovieService } from "../../services/movie.service";
import { UserService } from "../../services/user.service";

@Component({
  selector: "app-movie",
  templateUrl: "./movie.component.html"
})

export class MovieComponent {
  public movies: Observable<MovieInterface[]>;
  public error: string;
  public headers: string[] = ["Título", "Descripción", "Actores", "Director", "Costo del alquiler", "Cantidad en inventario"];
  public columns: string[];
  public isAuthenticated: boolean;
  public isAdmin: boolean;
  public buttons: ButtonModel[] = null;

  constructor(protected movieService: MovieService, authService: AuthService, userService: UserService) {
    this.GetInfo();
    this.isAuthenticated = authService.isAuthenticated();
    this.isAdmin = authService.isAdmin();
    const buttonBook = new ButtonModel();
    buttonBook.column= 'id';
    buttonBook.isVisible= true;
    buttonBook.label= 'Reservar';
    buttonBook.callback= id => {
      if (authService.isAuthenticated()) {
        userService.bookAMovie(authService.getCurrentUser().id, id).subscribe(value => {
          if (value.success) {
            console.log("Agregado con éxito");
          } else {
            console.log(value.errorMessage);
          }
        }, error => console.error(error));
      }
    };
    
    this.buttons = [buttonBook];

    if (this.isAdmin) {
      const buttonEditar = new ButtonModel();
      buttonEditar.column = 'id';
      buttonEditar.isVisible = true;
      buttonEditar.label = 'Editar';
      buttonEditar.callback = id => {
        if (authService.isAuthenticated()) {
          userService.bookAMovie(authService.getCurrentUser().id, id).subscribe(value => {
            if (value.success) {
              console.log("Agregado con éxito");
            } else {
              console.log(value.errorMessage);
            }
          }, error => console.error(error));
        }
      };
    }
  }

  public GetInfo() {
    this.movies = this.movieService.GetMovies();
    this.movies.subscribe(value => {
      if (value.length > 0) {
        this.columns = Object.keys(value[0]).filter((value, index) => {
          return (value != 'id' && value != 'idDirector' && value != 'actoresId');
        });
      }
    })
  }
}
