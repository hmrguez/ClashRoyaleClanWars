import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {CardsComponent} from "./components/cards/cards.component";
import {PlayersComponent} from "./components/players/players.component";
import {DashboardComponent} from "./components/dashboard/dashboard.component";
import {LogInComponent} from './components/log-in/log-in.component';
import {ClansComponent} from "./components/clans/clans.component";
import {FAQComponent} from "./components/faq/faq.component";
import {GraphComponent} from "./components/graph/graph.component";

const routes: Routes = [
  {path: '', component: DashboardComponent},
  {path: 'cards', component: CardsComponent},
  {path: 'players', component: PlayersComponent},
  {path: 'login', component: LogInComponent},
  {path: 'clans', component: ClansComponent},
  {path: 'faq', component: FAQComponent},
  {path: 'graph', component: GraphComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
