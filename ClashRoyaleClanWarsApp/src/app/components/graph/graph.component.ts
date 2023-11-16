import { Component, Query } from '@angular/core';
import { MessageService } from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';
import jsPDF from 'jspdf';
import { QueryService } from './query.service';
import { Observable, firstValueFrom } from 'rxjs';

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

    async getBattlesYear(q1 :QueryService){
        let datasets1 = [0,0,0,0,0,0,0,0,0,0,0,0]

        const func = ((data: any)=>{
            for (let index = 0; index < data.length; index++) {
                const element = data[index];
                let mes = element.month
                datasets1[mes-1] = element.amountBattles   
            }
        });

        const obeservable = await q1.getAll().toPromise();
        func(obeservable)
        
        return datasets1

    }

  
    async ngOnInit() {
        let datasets1: number[] = []
        let datasets2: number[] = []
        //create a queryService variable
        let q1 = this.queryService
        //get current year
        const baseUrl1 = q1.baseUrl

        const date = new Date();
        const currYear = date.getFullYear();
        const lastYear = currYear-1

        let labels = ['January', 'February','March','April','May','June','July','August','September','October','November','December'];
        q1.baseUrl += "/" + String(currYear)

        datasets1 = await this.getBattlesYear(q1)
        
        q1.baseUrl = baseUrl1
        q1.baseUrl += "/" + String(lastYear)

        datasets2 = await this.getBattlesYear(q1)
        
        q1.baseUrl = baseUrl1

        this.basicData = { 
            labels: labels, 
            datasets: [ 
                { 
                    label: String(currYear),
                    data: datasets1, 
                    fill: false, 
                    borderColor: '#AA2324', 
                    tension: 0.4, 
                }, 
                { 
                    label: String(lastYear), 
                    data: datasets2, 
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
