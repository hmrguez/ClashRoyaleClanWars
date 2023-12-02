import { Component } from '@angular/core';
import { PlayerService } from '../players/player.service';
import { OnInit } from '@angular/core';
import { IPlayerDto } from '../players/IPlayerDto';
import jsPDF from 'jspdf';

export interface Victories{
  victories: number,
  count :number,
}

@Component({
  selector: 'app-card-popularity',
  templateUrl: './card-popularity.component.html',
  styleUrls: ['./card-popularity.component.scss']
})
export class CardPopularityComponent implements OnInit{

  data:any
  options:any

  lb :string[] = []
  count : number[] = []



  constructor(public playerServ: PlayerService) {
}


    
  

  async getBattlesYear(){
    let datasets1 = [0,0,0,0,0,0,0,0,0,0,0,0]

    const func = ((data: IPlayerDto[])=>{
        for (let index = 0; index < data.length; index++) {
            const element = data[index];
            this.processData(element)
        }
    });

    const obeservable = await this.playerServ.getAll().toPromise();
    func(obeservable!)
    
    return datasets1

}

Save(){
  var canvas = document.querySelectorAll('canvas')[1];
  var img = canvas!.toDataURL("image/png");
  var doc = new jsPDF('landscape', 'px', 'a4' );
  doc.setFontSize(40);
  doc.text("Players with X amount of victories", 35, 25);
  doc.addImage(img, 'JPEG', 50, 50, 500,300);
  doc.save('victories.pdf');
}

  processData(playerData: any){
    let v = playerData.victories
    let found = false
   
    for (let index = 0; index < this.lb.length; index++) {
      var elem = this.lb[index]
      if (elem==v){
        this.count[index]++
        found = true
        break
      }
    }
    if (!found){
      this.lb.push(v)
      this.count.push(1)
    }
    

    }

    async ngOnInit() {
      const documentStyle = getComputedStyle(document.documentElement);
      const textColor = documentStyle.getPropertyValue('--text-color');
      const textColorSecondary = documentStyle.getPropertyValue('--text-color-secondary');
      const surfaceBorder = documentStyle.getPropertyValue('--surface-border');
      let datasets1: number[] = []
      datasets1 = await this.getBattlesYear()

      for (let i = 0; i < this.lb.length; i++) {
        for (let j = 0; j < this.lb.length; j++) {
          if (this.lb[i]<this.lb[j]){
            let temp = this.lb[j]
            this.lb[j] = this.lb[i]
            this.lb[i] = temp

            let temp2 = this.count[j]
            this.count[j] = this.count[i]
            this.count[i] = temp2
          }
          
        }
        
      }

      this.data = {
        labels: this.lb,
        datasets: [
            {
                label: 'Players with x amount of victories',
                data: this.count,
                backgroundColor: ['rgba(255, 159, 64, 0.2)', 'rgba(75, 192, 192, 0.2)', 'rgba(54, 162, 235, 0.2)', 'rgba(153, 102, 255, 0.2)'],
                borderColor: ['rgb(255, 159, 64)', 'rgb(75, 192, 192)', 'rgb(54, 162, 235)', 'rgb(153, 102, 255)'],
                borderWidth: 1
            }
        ]
    };

    this.options = {
        plugins: {
            legend: {
                labels: {
                    color: textColor
                }
            }
        },
        scales: {
            y: {
                beginAtZero: true,
                ticks: {
                    color: textColorSecondary
                },
                grid: {
                    color: surfaceBorder,
                    drawBorder: false
                }
            },
            x: {
                ticks: {
                    color: textColorSecondary
                },
                grid: {
                    color: surfaceBorder,
                    drawBorder: false
                }
            }
        }
    };

        
    }
  

}
