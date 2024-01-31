import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { EquipmentService } from '../equipment.service';
import { Point } from '../../../shared/model/point.model';

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrl: './delivery.component.css',
})
export class DeliveryComponent implements  OnInit {
points: Point[] = [];

  constructor(private equipmentService: EquipmentService, private cdRef: ChangeDetectorRef){}
  ngOnInit(): void {
    this.points.push({ longitude: 19.8369, latitude: 45.2517}, {longitude: 20.3091, latitude:44.8184})
  }

  startDelivery() {
    this.equipmentService.startDelivery().subscribe(
      (data) => console.log('Start delivery success!'),
      (err) => console.error('Error starting delivery: ', err),
    )
  }
  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }
  
  getMessage() {
    this.equipmentService.getMessage().subscribe(
      async (data: string[]) => {
        console.log(data)
        for (const str of data) {
          const [longitude, latitude] = str.split('/').map(Number);
          const point: Point = { latitude, longitude };
  
          this.points.push(point);
  
          this.cdRef.detectChanges();
  
          await this.delay(5000);
        }
  
        console.log('Points array:', this.points);
      },
      (err) => console.error('Error starting delivery: ', err),
    );
  }
}
