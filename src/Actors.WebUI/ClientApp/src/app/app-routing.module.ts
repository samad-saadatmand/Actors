import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ActorCreateComponent } from './pages/actor-create/actor-create.component';
import { ActorDetailComponent } from './pages/actor-detail/actor-detail.component';
import { MovieCreateComponent } from './pages/movie-create/movie-create.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'actor/create', component: ActorCreateComponent, pathMatch: 'full' },
  { path: 'actor/detail/:id', component: ActorDetailComponent, pathMatch: 'full' },
  { path: 'movie/create/:id', component: MovieCreateComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
