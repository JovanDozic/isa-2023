import { ChangeDetectorRef, Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CalendarEvent, CalendarView } from 'angular-calendar';
import { EventColor, MonthViewDay } from 'calendar-utils';
import { isSameDay, isSameMonth } from 'date-fns';
import { Subject } from 'rxjs';

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

  events: CalendarEvent[] = [
    {
      title: 'Event 1',
      start: new Date('2023-12-16 10:00:00'),
      end: new Date('2023-12-16 11:00:00'),
      color: { ...colors['red'] },
    },
    {
      title: 'Event 2',
      start: new Date('2023-12-16 15:00:00'),
      end: new Date('2023-12-16 16:00:00'),
    },
    {
      title: 'Event 3',
      start: new Date('2023-12-20 10:00:00'),
      end: new Date('2023-12-20 11:00:00'),
    }
  ];

  constructor(private cdr: ChangeDetectorRef) { }


  ngOnInit(): void {




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
    this.cdr.detectChanges();
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }

  setView(view: CalendarView) {
    this.view = view;
  }



}
