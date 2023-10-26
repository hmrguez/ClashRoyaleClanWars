
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';
import jsPDF from 'jspdf';

@Component({
  selector: 'app-root',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.scss'],
  providers: [MessageService]
})

export class GraphComponent {
  basicData: any; 
  basicOptions: any; 
  constructor( 
      private messageService: MessageService, 
      private primengConfig: PrimeNGConfig 
  ) { } 

 
  ngOnInit() { 
      this.basicData = { 
          labels: ['January', 'February', 'March',  
              'April', 'May', 'June', 'July'], 
          datasets: [ 
              { 
                  label: '2020', 
                  data: [65, 59, 80, 81, 56, 55, 40], 
                  fill: false, 
                  borderColor: '#AA2324', 
                  tension: 0.4, 
              }, 
              { 
                  label: '2021', 
                  data: [28, 48, 40, 19, 86, 27, 90], 
                  fill: false, 
                  borderColor: '#177300', 
                  tension: 0.4, 
              }, 
          ], 
      }; 
      this.basicOptions = { 
          title: { 
              display: true, 
              text: 'Article Views', 
              fontSize: 32, 
              position: 'top', 
          }, 
          scales: { 
              x: { 
                  ticks: { 
                      color: '#495057', 
                  }, 
                  grid: { 
                      color: '#ebedef', 
                  }, 
              }, 
              y: { 
                  ticks: { 
                      color: '#495057', 
                  }, 
                  grid: { 
                      color: '#ebedef', 
                  }, 
              }, 
          }, 
      }; 
  } 
  Export(){
    var canvas = document.querySelector("canvas");
    var canvas_img = canvas!.toDataURL("image/png",1.0);
    var pdf = new jsPDF('landscape','in', 'letter');
    pdf.addImage(canvas_img, 'PNG', 0, 0, 11, 8.5);
    pdf.save('test.pdf');
    
  }
}