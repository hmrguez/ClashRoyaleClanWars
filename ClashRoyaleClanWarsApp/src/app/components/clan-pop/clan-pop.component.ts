import { Component } from '@angular/core';
import { ClanService } from '../clans/clan.service';
import jsPDF from 'jspdf';

@Component({
  selector: 'app-clan-pop',
  templateUrl: './clan-pop.component.html',
  styleUrls: ['./clan-pop.component.scss']
})
export class ClanPopComponent {

  allClans :any[] = []

  data: any;

  options: any;

  constructor(private clanSer: ClanService){
    this.clanSer.getAll().subscribe((data)=> {
      this.allClans=data
      this.allClans = this.allClans.sort((a,b)=> (a.amountMembers<b.amountMembers)?1:-1)
      

      const documentStyle = getComputedStyle(document.documentElement);
        const textColor = documentStyle.getPropertyValue('--text-color');
        const surfaceBorder = documentStyle.getPropertyValue('--surface-border');
        
        this.data = {
            datasets: [
                {
                    data: [this.allClans[0].amountMembers, this.allClans[1].amountMembers,this.allClans[2].amountMembers,this.allClans[3].amountMembers,this.allClans[4].amountMembers,],
                    backgroundColor: [
                        documentStyle.getPropertyValue('--red-500'),
                        documentStyle.getPropertyValue('--green-500'),
                        documentStyle.getPropertyValue('--yellow-500'),
                        documentStyle.getPropertyValue('--bluegray-500'),
                        documentStyle.getPropertyValue('--blue-500')
                    ],
                    label: 'Clan Popularity'
                }
            ],
            labels: [this.allClans[0].name + "-  " + this.allClans[0].amountMembers
             ,this.allClans[1].name + "-  " + this.allClans[1].amountMembers,
             this.allClans[2].name+ "-  " + this.allClans[2].amountMembers,
             this.allClans[3].name + "-  " + this.allClans[3].amountMembers,
             this.allClans[4].name + "-  " + this.allClans[4].amountMembers,]
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
                r: {
                    grid: {
                        color: surfaceBorder
                    }
                }
            }
        };
    })

  }

  Save(){
    var canvas = document.querySelector('canvas');
    var img = canvas!.toDataURL("image/png");
    var doc = new jsPDF('portrait', 'px', 'a4' );
    doc.setFontSize(20);
    doc.text("Most Popular Clans", 35, 25);
    doc.addImage(img, 'JPEG', 50, 50, 300,300);
    doc.save('clansPopularity.pdf');
  }

}
