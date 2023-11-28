import { Component } from '@angular/core';
import { UsersService } from './users.service';
import { MessageService } from 'primeng/api';
import { User } from './UserDto';
import { IColumn, ColumnType} from '../grid/IColumn';
import { OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TokenStorageService } from 'src/app/services/token-storage.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent  {

  allUsers : any[] = []

  selectedUser !: any
  roleSelected !: any
  show = false

  roles = [
    {name:'user',value:0},{name:'admin',value:1},{name:'superadmin',value:2}
  ]

  constructor(private mess:MessageService, public serv:UsersService, private http: HttpClient, private token:TokenStorageService){
    this.serv.getAll().subscribe((data)=>{this.allUsers=data})
    
  }

  async ngOnInit() {
    this.allUsers = await this.LoadUsers()
  }

  async LoadUsers(){
    
    var users: any[] =[]
  
   
    //map play and only add id and name to this.allpayers
    const func = ((data: any)=>{
        users = data
    });
  
    const obeservable = await this.serv.getAll().toPromise();
    func(obeservable)

    return users

  }

  columns: IColumn[] =[
    
      {
        header: 'Username',
        field: 'name',
        type: ColumnType.String,
      },
    
  ]


  itemParsingFunction(data:any) : User{
    return {
      id : data.id,
      name : data.name,
      role :data.passwordHash
    }
  }

  Show(){
    this.show = !this.show
  }

  showError(message:string){
    this.mess.add({ severity: 'error', summary: 'Error', detail: message });
  }

  showSuccess(message:string){
    this.mess.add({ severity: 'success', summary: 'Success', detail: message });
  }
  
  Update(){



    if (!this.selectedUser || !this.roleSelected) {this.showError('Fields cannot be empty')
    return
  }
    let user = this.token.getUser()

    if (this.selectedUser.name==user){
     
      this.showError('You cannot change your own role')
      return
    }
   
    


    this.serv.update(this.selectedUser.id, this.roleSelected.value).subscribe((data)=>{
    this.showSuccess('Role Updated')
    console.log(data)}, (err)=>{this.showError(err.error)})

  }

}
