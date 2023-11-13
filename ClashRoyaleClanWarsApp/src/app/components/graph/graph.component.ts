import { Component, Query } from '@angular/core';
import { MessageService } from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';
import jsPDF from 'jspdf';
import { QueryService } from './query.service';

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.scss'],
  providers: [MessageService]
})
export class GraphComponent {

  basicData: any; 
    basicOptions: any; 
    constructor( 
        private messageService: MessageService, 
        private primengConfig: PrimeNGConfig ,
        public queryService:QueryService) {}


    Save(){
      var canvas = document.querySelector('canvas');
      var img = canvas!.toDataURL("image/png");
      var doc = new jsPDF('landscape', 'px', 'a4' );
      doc.setFontSize(40);
      doc.text("Popularidad del juego", 35, 25);
      doc.addImage(img, 'JPEG', 50, 50, 500,300);
      doc.save('graph.pdf');
    }

  
    ngOnInit() {
        //create a queryService variable
        let q1 = this.queryService
        //get current year
        const baseUrl = q1.baseUrl

        const date = new Date();
        const currYear = date.getFullYear();
        const lastYear = currYear-1

        q1.baseUrl += "/" + String(currYear)
        q1.getAll().subscribe((data)=>{
            console.log("DATA", data);
            let labels = ['January', 'February','March','April','May','June','July','August','September','October','November','December'];
            let datasets = [0,0,0,0,0,0,0,0,0,0,0,0]
            //hacer esto
        });

        q1.baseUrl = baseUrl
        q1.baseUrl += "/" + String(lastYear)
        q1.getAll().subscribe((data)=>{
            console.log("DATA", data);
            let labels = ['January', 'February','March','April','May','June','July','August','September','October','November','December'];
            let datasets = [0,0,0,0,0,0,0,0,0,0,0,0]
            //hacer esto
        });



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

}
