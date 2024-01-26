import { Component } from '@angular/core';
import { BrowserQRCodeReader } from '@zxing/browser';
import { Appointment, AppointmentStatus } from '../model/appointment.model';
import { CompanyManagementService } from '../company-management.service';
import Integer from '@zxing/library/esm/core/util/Integer';
import { UserManagementService } from '../../user-management/user-management.service';
import { EquipmentService } from '../../equipment-management/equipment.service';

@Component({
  selector: 'app-pickup-using-qr',
  templateUrl: './pickup-using-qr.component.html',
  styleUrl: './pickup-using-qr.component.css'
})
export class PickupUsingQrComponent {


  appointment: Appointment | undefined;
  qrCodeReader = new BrowserQRCodeReader();
  appointmentLoaded: boolean = false;
  appointmentExpired: boolean = false;
  appointmentProcessed: boolean = false;
  loadedQrSrc = '';
  appointmentCancelled: boolean = false;

  constructor(private companyService: CompanyManagementService, private userService: UserManagementService, private equipmentService: EquipmentService) { }

  onFileChange(event: Event) {
    this.appointmentLoaded = false;
    this.loadedQrSrc = '';
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length) {
      const file = input.files[0];
      this.scanQRCode(file);
    }
  }

  async scanQRCode(file: File) {
    try {
      const imageElement = new Image();
      const reader = new FileReader();
      reader.onload = () => {
        imageElement.src = reader.result as string;
        this.loadedQrSrc = imageElement.src;
        this.qrCodeReader.decodeFromImageElement(imageElement).then(result => {
          // console.log('QR Code result: ', result);
          // console.log(result.getText());
          this.getAppointment(result.getText());
        }).catch(err => {
          console.error('Error decoding QR Code:', err);
        });
      };
      reader.readAsDataURL(file);
    } catch (err) {
      console.error('Error decoding QR Code:', err);
    }
  }

  getAppointment(result: string) {
    const appointmentId = result.split('appointment-details/')[1];
    console.log('Appointment ID: ' + appointmentId);

    this.companyService.getAppointment(Number(appointmentId)).subscribe(
      (response: any) => {
        this.appointment = response;
        console.log("Appointment loaded: ", this.appointment);

        if (this.appointment == undefined) {
          return;
        }

        this.userService.getUserById(this.appointment.buyerId).subscribe(
          (response: any) => {
            if (this.appointment)
              this.appointment.buyer = response;
            console.log("Buyer loaded: ", this.appointment?.buyer);
          },
          (error) => {
            console.log("Error: ", error);
            this.appointmentLoaded = false;
            alert("Loading appointment failed!");
          }
        );

        this.companyService.getCompany(this.appointment.companyId).subscribe(
          (response: any) => {
            if (this.appointment)
              this.appointment.company = response;
            console.log("Company loaded: ", this.appointment?.company);
          },
          (error) => {
            console.log("Error: ", error);
            this.appointmentLoaded = false;
            alert("Loading appointment failed!");
          }
        );

        this.equipmentService.getEquipment().subscribe(
          (response: any) => {
            if (this.appointment) {
              this.appointment.equipment = [];

              this.appointment.equipmentIds?.forEach((equipmentId: number) => {
                const matchedEquipment = response.find((equipment: any) => equipment.id === equipmentId);
                if (matchedEquipment) {
                  this.appointment?.equipment.push(matchedEquipment);
                }
              });
              console.log("Equipment loaded: ", this.appointment.equipment);
            }
          },
          (error) => {
            console.log("Error: ", error);
            this.appointmentLoaded = false;
            alert("Loading appointment failed!");
          }
        );
        this.appointmentLoaded = true;
        this.appointmentProcessed = this.appointment.status == AppointmentStatus.PROCESSED;
        this.appointmentExpired = this.appointment.status == AppointmentStatus.EXPIRED;
        this.appointmentCancelled = this.appointment.status == AppointmentStatus.CANCELED;

        const fifteenMinutes = 15 * 60 * 1000;
        const currentTime = new Date().getTime();
        const appointmentTime = new Date(this.appointment.startTime).getTime();
        if (currentTime - appointmentTime > fifteenMinutes) {
          this.flagAppointmentAsExpired();
        }
      },
      (error) => {
        console.log("Error: ", error);
        this.appointmentLoaded = false;
        alert("Loading appointment failed!");
      }
    );
  }

  confirmPickup() {
    if (this.appointment == undefined) {
      return;
    }
    this.companyService.flagAppointmentAsPickedUp(this.appointment?.id).subscribe(
      (response: any) => {
        console.log("Pickup confirmed! " + response);
        this.appointmentProcessed = true;
      },
      (error) => {
        console.log("Error: ", error);
        alert("Confirming pickup failed!");
        this.appointmentProcessed = false;
      }
    );
  }

  cancelPickup() {
    if (this.appointment == undefined) {
      return;
    }
    this.companyService.flagAppointmentAsCancelled(this.appointment?.id).subscribe(
      (response: any) => {
        console.log("Pickup cancelled! " + response);
        this.appointmentCancelled = true;
      },
      (error) => {
        console.log("Error: ", error);
        alert("Cancelling pickup failed!");
        this.appointmentCancelled = false;
      }
    );
  }

  flagAppointmentAsExpired() {
    if (this.appointment == undefined) {
      return;
    }
    this.companyService.flagAppointmentAsExpired(this.appointment?.id).subscribe(
      (response: any) => {
        console.log("Appointment expired! " + response);
        this.appointmentExpired = true;
      },
      (error) => {
        console.log("Error: ", error);
        alert("Expiring appointment failed!");
        this.appointmentExpired = false;
      }
    );
  }




}
