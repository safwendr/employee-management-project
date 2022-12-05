import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { UserInput } from '../../auth.model';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-sign-in-page',
  templateUrl: './sign-in-page.component.html',
  styleUrls: ['./sign-in-page.component.scss']
})
export class SignInPageComponent implements OnInit {

  form!: FormGroup;

  constructor(
    private _authService: AuthService,
    private router: Router,
    private snackbar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      email: new FormControl(null, { validators: [Validators.required, Validators.email] }),
      password: new FormControl(null, { validators: [Validators.required] })
    })
  }


  login() {
    if (this.form.invalid) return;

    this._authService.login(this.form.value).subscribe(
      {
        next: res => {
          this.router.navigateByUrl('/employees');
        },
        error: err => {
          console.log('unauthorized', err);
          this.router.navigateByUrl('/');
          this.snackbar.open('invalid credentiels', 'OK', {
            duration: 5000
          });
        }
      }
    )

  }

}
