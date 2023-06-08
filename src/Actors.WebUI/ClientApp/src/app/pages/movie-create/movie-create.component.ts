import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { firstValueFrom } from 'rxjs';
import { ActorClient } from 'src/app/core/services/actor.client';

@Component({
  selector: 'app-movie-create',
  templateUrl: './movie-create.component.html',
  styleUrls: ['./movie-create.component.css'],
})
export class MovieCreateComponent {
  movieForm: FormGroup;
  id: any;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private client: ActorClient,
    private toastr: ToastrService
  ) {
    this.id = this.route.snapshot.paramMap.get('id');

    this.movieForm = new FormGroup({
      name: new FormControl('', [
        Validators.required,
        Validators.maxLength(256),
      ]),
      releaseDate: new FormControl('', Validators.required),
    });
  }

  ngOnInit() {}

  async onSubmit() {
    if (this.movieForm.valid) {
      await firstValueFrom(
        this.client.addActorMovie(
          this.id,
          this.movieForm.controls['name'].value,
          this.movieForm.controls['releaseDate'].value
        )
      )
        .then(() => {
          this.toastr.success('Movie Created succesfuly');
          this.movieForm.reset();
          this.router.navigate(['/actor/detail', this.id]);
        })
        .finally(() => {});
    }
  }
}
