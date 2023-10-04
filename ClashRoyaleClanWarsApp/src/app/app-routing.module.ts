import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {CardsComponent} from "./components/cards/cards.component";
import {PlayersComponent} from "./components/players/players.component";
import {DashboardComponent} from "./components/dashboard/dashboard.component";
import {LogInComponent} from './components/log-in/log-in.component';
import {ClansComponent} from "./components/clans/clans.component";

const routes: Routes = [
  {path: '', component: DashboardComponent},
  {path: 'cards', component: CardsComponent},
  {path: 'players', component: PlayersComponent},
  {path: 'login', component: LogInComponent},
  {path: 'clans', component: ClansComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
