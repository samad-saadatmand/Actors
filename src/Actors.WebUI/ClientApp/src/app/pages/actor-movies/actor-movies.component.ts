import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { ActorClient } from 'src/app/core/services/actor.client';

@Component({
  selector: 'app-actor-movies',
  templateUrl: './actor-movies.component.html',
  styleUrls: ['./actor-movies.component.css'],
})
export class ActorMoviesComponent {
  @Input() id: string | undefined;
  @Output() mostRecentMovies = new EventEmitter<any[]>();
  movies: any[] = [];

  constructor(private route: ActivatedRoute, private client: ActorClient) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) this.getActorMovies(id);
  }

  async getActorMovies(id: string) {
    let data = await firstValueFrom(this.client.getActorMovies(id));
    this.mostRecentMovies.emit( data ? data.slice(0, 3):[]);
    this.movies = data ? data : this.movies;
  }
}
