import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { MovieService } from '../../services/movie.service';

@Component({
  selector: 'app-movie-create',
  templateUrl: './movie-create.component.html'
})

export class MovieCreateComponent {
  public isAuthorized: boolean = false;
  public movieForm: FormGroup;
  public callback: Function;

  constructor(formBuilder: FormBuilder, authService: AuthService, private movieService: MovieService, private router: Router) {
    this.isAuthorized = authService.isAdmin();
    if (this.isAuthorized) {
      this.movieForm = formBuilder.group({
        id: [null],
        titulo: ['', [Validators.required, Validators.maxLength(250)]],
        descripcion: ['', [Validators.required]],
        costoAlquiler: [null, [Validators.required]],
        cantidadInventario: [null, [Validators.required]],
        idDirector: [null, [Validators.required]],
        actoresId: [null, [Validators.required]]
      });
    }
    this.callback = value => {
      if (value.valid) {
        const movie = value.value;

        this.movieService.SaveMovie(movie).subscribe(value => {
          if (value.success) {
            router.navigate(['/movie']);
          } else {
            console.log(value.errorMessage);
          }
        }, error => console.error(error));
      }
    }
  }
}
