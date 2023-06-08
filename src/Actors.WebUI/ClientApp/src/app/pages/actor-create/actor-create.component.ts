import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { firstValueFrom } from 'rxjs';
import { ActorClient } from 'src/app/core/services/actor.client';

@Component({
  selector: 'app-actor-create',
  templateUrl: './actor-create.component.html',
  styleUrls: ['./actor-create.component.css'],
})
export class ActorCreateComponent {
  actorForm: FormGroup;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private client: ActorClient,
    private toastr: ToastrService
  ) {
    this.actorForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.maxLength(256)]],
      lastName: ['', [Validators.required, Validators.maxLength(256)]],
      age: ['', [Validators.required]],
    });
  }

  async onSubmit() {
    if (this.actorForm.valid) {     

      await firstValueFrom(
        this.client.addActor(
          this.actorForm.controls['firstName'].value,
          this.actorForm.controls['lastName'].value,
          this.actorForm.controls['age'].value
        )
      )
        .then(() => {
          this.toastr.success('Actor Created succesfuly');
          this.actorForm.reset();
          this.router.navigate(['/']);
        })
        .finally(() => {});
    }
  }
}
