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
import { UsersService } from '../users/users.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent {

  @ViewChild("grid") grid: GridComponent = {} as GridComponent;

  stateOptions: any[] = [{label: 'View As Player', value: false}, {label: 'View As Admin', value: true}];
  value = false

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





 
  

  constructor(public playerService: PlayerService, private userSer: UsersService, public tokens :TokenStorageService, private mess:MessageService,private challengeSer:ChallengeService, private http:HttpClient, private cardser:CardService) { 
    this.is_Admin = this.tokens.isAdmin() || this.tokens.isSuperAdmin()

   
      var user = this.tokens.getUser()
      var url = this.playerService.baseUrl 
      
      this.updateCurrentUserCards()

    this.http.get(url).subscribe((data:any)=>{
      this.allPlayers=data
    })
    this.cardser.getAll().subscribe((data)=>{
      this.allcards = data
    })
    
    var url1 = this.challengeSer.baseUrl

    this.challengeSer.baseUrl+= '/open'
    this.challengeSer.getAll().subscribe((data)=>{
      this.allChallenges = data
    })

    this.challengeSer.baseUrl = url1
    
  }

  updateCurrentUserCards(){
    var user = this.tokens.getUser()
      var url = this.playerService.baseUrl 
      
      this.http.get(url+'/'+user).subscribe((data: any)=>{
        this.currentuser = data[0]
        this.http.get(url + '/' + this.currentuser.id + '/cards').subscribe((data2)=>{
          this.currentusercards = data2
          
        })
      })
  }

  

  
      visible = false
      visibleu =false
      visiblep = false
      visibled = false

      newusername!:string

      ShowDialogUsername(){
        this.visibleu = true
      }

      ShowDialogPassword(){
        this.visiblep = true
      }

      ShowDialogDonate(){
        this.visibled = true
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

      donateAmountC !: any
      donateCard !: any

      DonateCard(){
        this.visibled = false
        if (!this.donateCard || !this.donateAmountC) {
          this.showError('Fill all fields')
          return
      }

      let url = this.playerService.baseUrl + '/' + this.currentuser.id + '/donate' ;

      

    this.http.post(url,{'cardId':this.donateCard.id,'amount':this.donateAmountC}).subscribe((data)=>{
      this.showSuccess("Donated")
    },(err)=>{
      this.showError(err.error)
    })

    }

      ChangeUsername(){
        this.visibleu = false

        if (!this.newusername){
          this.showError('Username cannot be empty')
          return
        }

        let url = this.playerService.baseUrl + '/'+ this.currentuser.id + '/' + this.newusername
        console.log(this.tokens.getUser())

        this.http.patch(url,{}).subscribe((data)=>{
        
          this.tokens.updateUser(JSON.stringify( this.newusername))
          this.currentuser.alias = this.newusername
          this.showSuccess('Username changed')
          console.log(this.tokens.getUser())
        },(err)=>{
          this.visibleu = false
          this.showError(err.error)
          console.log(err)
        })
      }

      pass !: string
      confPass!: string

      ChangePassword(){
        this.visiblep=false

        if (!this.pass||!this.confPass){
          this.showError('Fill all fields')
          return
        }

        if (this.pass != this.confPass){
          this.showError('Passwords do not match')
          return
        }

        var url = this.userSer.baseUrl  + '/password'
        console.log(url)

        this.http.put(url, {'password': this.pass, 'id': this.tokens.getToken()}).subscribe((data)=>{
          this.showSuccess('Password Changed')

        },(err)=>{
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
      this.playerService.getAll().subscribe((data)=>{this.allPlayers = data})
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

      if (this.selectedUp.id ==this.currentuser.id){
        this.tokens.updateUser(JSON.stringify( this.aliasUp))
      }
      this.updateCurrentUserCards()
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

    if (id == this.currentuser.id){
      this.showError('cannot delete yourself')
      return
    }

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

      this.playerService.getAll().subscribe((data)=>{this.allPlayers=data})
      this.grid.loadData()

      this.updateCurrentUserCards()

      
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
