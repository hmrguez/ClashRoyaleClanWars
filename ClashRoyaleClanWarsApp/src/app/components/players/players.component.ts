import {Component} from '@angular/core';
import {ColumnType, IColumn} from "../grid/IColumn";
import {PlayerService} from "./player.service";
import { IPlayerDto } from './IPlayerDto';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { MessageService } from 'primeng/api';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ViewChild } from '@angular/core';
import { GridComponent } from '../grid/grid.component';
import { isPlatformBrowser } from '@angular/common';
import { CardService } from '../cards/card.service';
import { ChallengeService } from '../challenge/challenge.service';
import { OnInit } from '@angular/core';
import { TimeScale } from 'chart.js';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent {

  @ViewChild("grid") grid: GridComponent = {} as GridComponent;

  columns: IColumn[] = [
    {
      header: 'Alias',
      field: 'alias',
      type: ColumnType.String,
    },
    {
      header: 'Elo',
      field: 'elo',
      type: ColumnType.Number,
    },
    {
      header: 'Level',
      field: 'level',
      type: ColumnType.Number,
    },
    {
      header: 'Victories',
      field: 'victories',
      type: ColumnType.Number,
    },
    {
      header: 'Card Amount',
      field: 'cardAmount',
      type: ColumnType.Number,
    },
    {
      header: 'Max Elo',
      field: 'maxElo',
      type: ColumnType.Number,
    },
  ]

  allPlayers :any[] = []

  is_Admin = false
  visibleAdd = false
  visibleUpdate = false
  visibleDelete = false
  visibleDonate = false
  visibleAssign = false
  visibleChallenge =false


  aliasAdd !: string
  eloAdd !: number
  levelAdd !: number

  aliasUp !: string
  eloUp!:number
  levelUp!:number
  selectedUp!: any

  selectedDelete!: any

  selectedPlayer!:any
  selectedCard!:any
  amount=1

  cards !:any

  allcards !:any
  allChallenges!:any[]

  currentuser !:any
  currentusercards !:any



 
  

  constructor(public playerService: PlayerService, public tokens :TokenStorageService, private mess:MessageService,private challengeSer:ChallengeService, private http:HttpClient, private cardser:CardService) { 
    this.is_Admin = this.tokens.isAdmin() || this.tokens.isSuperAdmin()

    if (!this.is_Admin){
      var user = this.tokens.getUser()
      var url = this.playerService.baseUrl 
      
      this.playerService.baseUrl = url+ '/'+ user
      this.playerService.getAll().subscribe((data: any[])=>{
        this.currentuser = data[0]
        console.log(this.currentuser)
        this.playerService.baseUrl = url + '/' + this.currentuser.id + '/cards'
        this.playerService.getAll().subscribe((data2)=>{
          this.currentusercards = data2
          this.playerService.baseUrl = url
        })
      })

    }
    
    this.playerService.getAll().subscribe((data)=>{
      this.allPlayers=data
      
    })
    this.cardser.getAll().subscribe((data)=>{
      this.allcards = data
    })

    this.challengeSer.baseUrl+= '/open'
    this.challengeSer.getAll().subscribe((data)=>{
      this.allChallenges = data
    })


      
      
    

    
  }

  

  
      visible = false
      visibleu =false

      newusername!:string

      ShowDialogUsername(){
        this.visibleu = true
      }
      ShowDialog(){
        this.visible = true
      }

      showError(message:string){
        this.mess.add({ severity: 'error', summary: 'Error', detail: message });
      }
    
      showSuccess(message:string){
        this.mess.add({ severity: 'success', summary: 'Success', detail: message });
      }

      ChangeUsername(){
        if (!this.newusername){
          this.visibleu = false
          this.showError('Username cannot be empty')
          return
        }

        let url = this.playerService.baseUrl + '/'+ this.currentuser.id + '/' + this.newusername

        this.http.patch(url,{}).subscribe((data)=>{
          this.visibleu = false
          this.tokens.updateUser(this.newusername)
          this.currentuser.alias = this.newusername
          this.showSuccess('Username changed')
        },(err)=>{
          this.visibleu = false
          this.showError(err.error)
        })
      }

 

  showAdd(){
    this.visibleAdd= !this.visibleAdd
    this.visibleUpdate = false
    this.visibleDelete = false
    this.visibleDonate= false
    this.visibleAssign = false
    this.visibleChallenge =false
    
  }

  showUpdate(){
    this.visibleUpdate = !this.visibleUpdate
    this.visibleAdd = false
    this.visibleDelete = false
    this.visibleDonate= false
    this.visibleAssign = false
    this.visibleChallenge =false
  }

  showDelete(){
    this.visibleDelete = !this.visibleDelete
    this.visibleAdd = false
    this.visibleUpdate = false
    this.visibleDonate= false
    this.visibleAssign = false
    this.visibleChallenge =false
  }

  showDonate(){
    this.visibleDonate = !this.visibleDonate
    this.visibleAdd = false
    this.visibleUpdate = false
    this.visibleDelete = false
    this.visibleAssign = false
    this.visibleChallenge =false
  }

  showAssign(){
    this.visibleAssign = !this.visibleAssign 
    this.visibleAdd = false
    this.visibleUpdate = false
    this.visibleDelete = false
    this.visibleDonate = false
    this.visibleChallenge =false

  }

  showChallenge(){
    this.visibleChallenge = !this.visibleChallenge
    this.visibleAdd = false
    this.visibleUpdate = false
    this.visibleDelete = false
    this.visibleDonate = false
    this.visibleAssign = false
  }

  Post(){
    if (!this.eloAdd || !this.levelAdd || !this.aliasAdd){
      this.showError("Fields cannot be empty")
      return
    }

    this.http.post(this.playerService.baseUrl, {'elo':this.eloAdd, 'level':this.levelAdd, 'alias':this.aliasAdd}).subscribe((data)=>{
      this.showSuccess('Player Created')
      this.grid.loadData()
    }, (err)=>{this.showError(err.error)})

  }

  Update(){
    if (!this.eloUp && !this.aliasUp && !this.levelUp){
      this.showError('Not all fields can be empty')
      return
    }

    if (!this.selectedUp){
      this.showError('You need to select a player')
      return
    }

    if(!this.eloUp) this.eloUp = this.selectedUp.elo
    if (!this.aliasUp) this.aliasUp = this.selectedUp.alias
    if (!this.levelUp) this.levelUp = this.selectedUp.level

    var id = this.selectedUp.id

    this.playerService.update(id, {'alias': this.aliasUp, 'elo': this.eloUp, 'level':this.levelUp, 'id': id, 'victories': this.selectedUp.victories,
    'cardAmount': this.selectedUp.cardAmount,  'maxElo': this.selectedUp.maxElo, 'favoriteCard': this.selectedUp.favoriteCard}).subscribe((data)=>{
      this.showSuccess('Updated')
      this.playerService.getAll().subscribe((data)=>{this.allPlayers=data})
      this.grid.loadData()
    }, (err)=>{
      this.showError(err.error)
    })
  
  }

  Delete(){
    if (!this.selectedDelete){
      this.showError('Select a player to delete')
      return
    }

    var id = this.selectedDelete.id

    this.playerService.delete(id).subscribe((data)=>{
      this.showSuccess('Deleted')
      this.grid.loadData()
    }, (err)=>{
      this.showError(err.error)
    })
  }

  getCards(){
    if (this.selectedPlayer){
      let url = this.playerService.baseUrl
      + '/' + this.selectedPlayer.id + "/cards"

      this.http.get(url).subscribe((data)=>{this.cards=data
      console.log(this.cards)}, (err)=>console.log(err))
    }
  }

  donateAmount = 1
    
  Donate(){
    if (!this.selectedPlayer || !this.selectedCard){
      this.showError('Select a card and a player')
      return
    }

    let url = this.playerService.baseUrl 
    + '/' + this.selectedPlayer.id + '/donate' ;

    console.log('cardId ' + this.selectedCard.id + '  amount' +this.donateAmount)

    this.http.post(url,{'cardId':this.selectedCard.id,'amount':this.donateAmount, 'clanId':2}).subscribe((data)=>{
      this.showSuccess("Donated")
    },(err)=>{
      this.showError(err.error)
    })

  }

  playerAssign !: any
  cardAssign !: any

  AssignCards(){

    if (!this.playerAssign || !this.cardAssign){
      this.showError('Select a card and a player')
    }

    let url = this.playerService.baseUrl + '/'+this.playerAssign.id + '/cards/' + this.cardAssign.id

    this.http.post(url,{}).subscribe((data)=>{
      this.showSuccess("Cards assigned")
      

    },(err)=>{
      this.showError(err.error)
      console.log(err)
    })

  }

  challenge !: any
  playerChallenge !: any
  reward!: number

  Challenge(){
    if (!this.challenge || !this.playerChallenge || !this.reward){
      this.showError('No fields can be empty')
      return
    }

    let url = this.playerService.baseUrl + '/'+this.playerChallenge.id + '/challenge/' + this.challenge.id

    this.http.post(url,{'reward': this.reward}).subscribe((data)=>{
      this.showSuccess("Challenge assigned")
      

    },(err)=>{
      this.showError(err.error)
      console.log(err)
    })

  }

    
  
 
}
