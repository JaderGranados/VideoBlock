import { Component, Input } from '@angular/core';
import { ButtonModel } from '../../models/button.model';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html'
})

export class TableComponent{
  @Input() headers: string[];
  @Input() data: any[];
  @Input() columns: string[];
  @Input() buttons: ButtonModel[];
}

