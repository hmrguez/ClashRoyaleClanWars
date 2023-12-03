import {Component, ViewChild} from '@angular/core';
import {UsersService} from './users.service';
import {MessageService} from 'primeng/api';
import {User} from './UserDto';
import {ColumnType, IColumn} from '../grid/IColumn';
import {HttpClient} from '@angular/common/http';
import {TokenStorageService} from 'src/app/services/token-storage.service';
import {GridComponent} from '../grid/grid.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent {

  @ViewChild('grid') grid: GridComponent = {} as GridComponent

  allUsers: any[] = []

  selectedUser !: any
  roleSelected !: any

  selectedUserP !: any
  pass !: string
  confPass !: string
  show = false
  showP = false

  roles = [
    {name: 'user', value: 0}, {name: 'admin', value: 1}, {name: 'superadmin', value: 2}
  ]
  columns: IColumn[] = [

    {
      header: 'Username',
      field: 'username',
      type: ColumnType.String,
    },
    {
      header: 'Role',
      field: 'role',
      type: ColumnType.String,
    }

  ]

  constructor(private mess: MessageService, public serv: UsersService, private http: HttpClient, private token: TokenStorageService) {
    this.serv.getAll().subscribe((data) => {
      this.allUsers = data
    })

  }

  async ngOnInit() {
    this.allUsers = await this.LoadUsers()
  }

  async LoadUsers() {

    var users: any[] = []


    //map play and only add id and name to this.allpayers
    const func = ((data: any) => {
      users = data
    });

    const obeservable = await this.serv.getAll().toPromise();
    func(obeservable)

    return users

  }

  ChangePassword() {
    if (!this.selectedUserP || !this.pass || !this.confPass) {
      this.showError('Fields cannot be empty')
      return
    }
    if (this.pass != this.confPass) {
      this.showError('Passwords do not match')
      return
    }


    let user = this.selectedUserP.id

    const passwordWrapper = {
      id: user,
      password: this.pass
    }
    console.log(passwordWrapper)

    let url = this.serv.baseUrl + '/password'

    this.http.put(url, passwordWrapper).subscribe((data) => {
        this.showSuccess('Password Updated')
        this.grid.loadData()
        console.log(data)
      },
      (err) => {
        this.showError(err.error)
      })


  }


  itemParsingFunction(data: any): User {
    return {
      id: data.id,
      username: data.username,
      role: data.role,
      playerId: data.playerId
    }
  }

  Show() {
    this.show = !this.show
    this.showP = false
  }

  ShowPass() {
    this.showP = !this.showP
    this.show = false
  }

  showError(message: string) {
    this.mess.add({severity: 'error', summary: 'Error', detail: message});
  }

  showSuccess(message: string) {
    this.mess.add({severity: 'success', summary: 'Success', detail: message});
  }

  Update() {
    if (!this.selectedUser || !this.roleSelected) {
      this.showError('Fields cannot be empty')
      return
    }
    let user = this.token.getUser()

    if (this.selectedUser.name == user) {

      this.showError('You cannot change your own role')
      return
    }


    this.serv.update(this.selectedUser.id, this.roleSelected.value).subscribe((data) => {
      this.showSuccess('Role Updated')
      this.grid.loadData()

      console.log(data)
    }, (err) => {
      this.showError(err.error)
    })

  }

}
