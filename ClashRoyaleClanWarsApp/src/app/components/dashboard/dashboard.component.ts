import { Component, OnInit } from '@angular/core';



@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  
})
export class DashboardComponent implements OnInit{
 
  images: any[] = [];



  responsiveOptions: any[] =[
    {
      breakpoint: '1024px',
      numVisible: 5
   
    },
    {
      breakpoint: '768px',
      numVisible: 3
     
    },
    {
      breakpoint: '560px',
      numVisible: 1
  
    }
  ]
  
  constructor() { }

  ngOnInit() {
  var path = '/assets/gallery/'

    for (let i = 1; i <= 5; i++) {
      this.images.push({
        itemImageSrc: path + i + '.jpg',
        thumbnailImageSrc: path + i + '.jpg',
        alt: 'Description for Image ' + i,
        title: 'Title ' + i
      });
    }
    

  
  }

}
