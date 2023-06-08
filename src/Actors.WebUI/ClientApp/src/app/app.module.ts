import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './pages/home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { ActorListComponent } from './pages/actor-list/actor-list.component';
import { ActorCreateComponent } from './pages/actor-create/actor-create.component';
import { ActorMoviesComponent } from './pages/actor-movies/actor-movies.component';
import { ActorDetailComponent } from './pages/actor-detail/actor-detail.component';
import { MovieCreateComponent } from './pages/movie-create/movie-create.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ActorMoviesComponent,
    ActorDetailComponent,
    ActorListComponent,
    ActorCreateComponent,
    MovieCreateComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
