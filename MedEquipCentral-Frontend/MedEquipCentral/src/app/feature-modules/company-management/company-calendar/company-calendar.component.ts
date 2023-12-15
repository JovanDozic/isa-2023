import { ChangeDetectorRef, Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CalendarEvent, CalendarView } from 'angular-calendar';
import { EventColor, MonthViewDay } from 'calendar-utils';
import { isSameDay, isSameMonth } from 'date-fns';
import { Subject } from 'rxjs';
import { CompanyManagementService } from '../company-management.service';
import { UserManagementService } from '../../user-management/user-management.service';
import { AuthService } from '../../../core/auth/auth.service';

const colors: Record<string, EventColor> = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3',
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF',
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA',
  },
};

@Component({
  selector: 'app-company-calendar',
  templateUrl: './company-calendar.component.html',
  styleUrl: './company-calendar.component.css'
})
export class CompanyCalendarComponent implements OnInit {

  view: CalendarView = CalendarView.Month;
  viewDate: Date = new Date();
  refresh = new Subject<void>();
  activeDayIsOpen: boolean = false;
  CalendarView = CalendarView;

  events: CalendarEvent[] = [];

  constructor(private appointmentService: CompanyManagementService, private authService: AuthService) { }


  ngOnInit(): void {
    const user = this.authService.user$.getValue();
    console.log("Ulogovan gospo:");
    console.log(user);
    if (user.companyId) {
      this.getAppointments(user.companyId);
    }
  }

  getAppointments(companyId: number) {
    this.appointmentService.getCompanyAppointments(companyId).subscribe(appointments => {
      appointments.forEach(appointment => {
        const startTime = new Date(appointment.startTime);
        const endTime = new Date(startTime.getTime() + appointment.duration * 60000); // 60000 milliseconds in a minute
      
        // Format: "Appointment for 1 [10:00 - 11:00]"
        const title = `Appointment for ${appointment.buyerId} [${startTime.toLocaleTimeString('en-GB', { hour: '2-digit', minute: '2-digit' })} - ${endTime.toLocaleTimeString('en-GB', { hour: '2-digit', minute: '2-digit' })}]`;
      
        this.events.push({
          title: title,
          start: startTime,
          end: endTime,
          color: { ...colors['red'] },
        });
      });
      
      this.refresh.next();
    });
  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }

  setView(view: CalendarView) {
    this.view = view;
  }



}
