import { Component } from '@angular/core';
import { FirstQueryComponent } from '../first-query/first-query.component';
import { SecondQueryComponent } from '../second-query/second-query.component';
import { ThirdQueryComponent } from '../third-query/third-query.component';
import { FourthQueryComponent } from '../fourth-query/fourth-query.component';
import { FifthQueryComponent } from '../fifth-query/fifth-query.component';
import { SixthQueryComponent } from '../sixth-query/sixth-query.component';

@Component({
  selector: 'app-query-viewer',
  templateUrl: './query-viewer.component.html',
  styleUrls: ['./query-viewer.component.scss']
})
export class QueryViewerComponent {

  constructor(){
  }

}
