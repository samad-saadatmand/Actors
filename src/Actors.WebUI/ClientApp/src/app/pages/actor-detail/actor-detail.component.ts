import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { ActorClient } from 'src/app/core/services/actor.client';

@Component({
  selector: 'app-actor-detail',
  templateUrl: './actor-detail.component.html',
  styleUrls: ['./actor-detail.component.css'],
})
export class ActorDetailComponent {
  actor: any;
  mostRecentMovies:any[] = [];

  constructor(private route: ActivatedRoute, private client: ActorClient) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) this.getActorInfo(id);
  }

  async getActorInfo(id: string) {
    this.actor = await firstValueFrom(this.client.getActor(id));
  }
  getMostRecentMovies(mostRecentMovies: any){
    this.mostRecentMovies = mostRecentMovies;
  }
}
