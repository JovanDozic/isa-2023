import {Component, OnInit} from '@angular/core';
import {AuthService} from "../auth.service";
import {ActivatedRoute, Router} from "@angular/router";
import {HttpParams} from "@angular/common/http";

@Component({
  selector: 'app-verification',
  standalone: true,
  imports: [],
  templateUrl: './verification.component.html',
  styleUrl: './verification.component.css'
})
export class VerificationComponent implements OnInit{
  private userId!: number;
  constructor(private authService: AuthService, private router: Router, private route: ActivatedRoute) {  }
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userId = params['userId'];
    })
    this.authService.verify(this.userId).subscribe({
      next: () => {
        this.router.navigate(['home']);
      },
    });
  }

}
