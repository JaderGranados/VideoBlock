import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { PersonaInterface } from '../../interfaces/persona.interface';
import { PersonaService } from '../../services/persona.service';

@Component({
  selector: 'app-form-movie',
  templateUrl: './form-movie.component.html'
})

export class FormMovieComponent implements OnInit {
  @Input() public movieForm: FormGroup;
  @Input() public callback: Function;
  public actores: PersonaInterface[];

  constructor(personaService: PersonaService) {
    personaService.getAll().subscribe(value => {
      this.actores = value;
    }, error => console.error(error));
  }
  ngOnInit(): void {

  }

  public onFormSubmit() {
    this.callback(this.movieForm);
  }
}
