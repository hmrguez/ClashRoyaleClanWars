import { Component } from '@angular/core';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { PlayerService } from '../players/player.service';


@Component({
  selector: 'app-playerview',
  templateUrl: './playerview.component.html',
  styleUrls: ['./playerview.component.scss']
})
export class PlayerviewComponent {

  player!: any

  constructor(private token:TokenStorageService, private playerSer:PlayerService){
    var user = this.token.getUser()
    var url = this.playerSer.baseUrl + '/' + user
    this.playerSer.getAll().subscribe((data)=>{this.player=data})
    this.player = this.player[0]
  }



}
