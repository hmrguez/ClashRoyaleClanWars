import { Component } from '@angular/core';
import { GridComponent } from '../grid/grid.component';
import { ViewChild } from '@angular/core';
import { Challenge } from './ChallengeDto';
import { ChallengeService } from './challenge.service';
import { IColumn, ColumnType } from '../grid/IColumn';
import { MessageService } from 'primeng/api';
import { TokenStorageService } from 'src/app/services/token-storage.service';


@Component({
  selector: 'app-challenge',
  templateUrl: './challenge.component.html',
  styleUrls: ['./challenge.component.scss']
})
export class ChallengeComponent {

  @ViewChild("grid") grid: GridComponent = {} as GridComponent;

  columns: IColumn[] = [
    {
      header: 'Name',
      field: 'name',
      type: ColumnType.String,
    },
    {
      header: 'Description',
      field: 'description',
      type: ColumnType.String,
    },
    {
      header: 'Cost',
      field: 'cost',
      type: ColumnType.Number,
    },
    {
      header: 'AmountReward',
      field: 'amountReward',
      type: ColumnType.Number,
    },
    {
      header: 'StartDate',
      field: 'startDate',
      type: ColumnType.String,
    },
    {
      header: 'DurationInHours',
      field: 'durationInHours',
      type: ColumnType.Number,
    },
    {
      header: 'IsOpen',
      field: 'isOpen',
      type: ColumnType.Boolean,
    },
    {
      header: 'MinLevel',
      field: 'minLevel',
      type: ColumnType.Number,
    },
    {
      header: 'LossLimit',
      field: 'lossLimit',
      type: ColumnType.Number,
    },
     
]

  allChallenges :any[] = []

  isAdmin = false
  visibleAdd = false
  visibleUpdate = false
  visibleDelete = false
  visibleDonate = false
  visibleAssign = false

  constructor(private tokens: TokenStorageService, private mess:MessageService, public challengeSer:ChallengeService ){
    this.isAdmin = this.tokens.isAdmin() || this.tokens.isSuperAdmin()
    this.challengeSer.getAll().subscribe((data)=>{this.allChallenges=data})
  }

  itemParsingFunction(data:any):Challenge{
    return {
      id: data.id,
      name: data.name,
      description: data.description,
      cost: data.cost,
      amountReward: data.amountReward,
      startDate: data.startDate,
      durationInHours: data.durationInHours,
      isOpen: data.isOpen,
      minLevel: data.minLevel,
      lossLimit: data.lossLimit
    }
  }

  showError(message:string){
    this.mess.add({ severity: 'error', summary: 'Error', detail: message });
  }

  showSuccess(message:string){
    this.mess.add({ severity: 'success', summary: 'Success', detail: message });
  }

  showAdd(){
    this.visibleAdd= !this.visibleAdd
    this.visibleDelete = false
    
    
  }

  namePost !:string
  descriptionPost !:string
  costPost !:number
  amountRewardPost !:number
  startDatePost !:Date
  durationInHoursPost !:number
  minLevelPost !:number
  lossLimitPost !:number
  isOpenPost = false

  Post(){
    if (!this.namePost || !this.descriptionPost || !this.costPost || !this.amountRewardPost ||!this.startDatePost||!this.durationInHoursPost||!this.minLevelPost||!this.lossLimitPost){
      this.showError('Need to fill all fields')
      return
    }

    var body: Challenge = {
      id:1,
      name:this.namePost,
      description:this.descriptionPost,
      cost:this.costPost,
      amountReward:this.amountRewardPost,
      startDate:this.startDatePost.toJSON(),
      durationInHours:this.durationInHoursPost,
      isOpen:this.isOpenPost,
      minLevel:this.minLevelPost,
      lossLimit:this.lossLimitPost
    }

    this.challengeSer.create(body).subscribe((data)=>{
      this.showSuccess('Challenge inserted')
      this.grid.loadData()
      this.challengeSer.getAll().subscribe((data)=>{this.allChallenges=data})
      
    },(err)=>{
      console.log(err)
      this.showError('Could not insert \n' + err.error)
    })
  }

  showDelete(){
    this.visibleDelete = !this.visibleDelete
    this.visibleAdd = false
    
  }

  selectedChallenge !: any

  Delete(){
    if (!this.selectedChallenge){
      this.showError('Need to select a challenge')
      return
    }

    this.challengeSer.delete(this.selectedChallenge.id).subscribe((data)=>{
      this.showSuccess('Challenge deleted')
      this.grid.loadData()
      this.challengeSer.getAll().subscribe((data)=>{this.allChallenges=data})
      
    },(err)=>{
      this.showError('Could not delete \n' + err.error)
    })
  }

}
