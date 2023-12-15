import { Component, OnInit } from '@angular/core';
import { CalendarEvent } from 'angular-calendar';
import { EventColor } from 'calendar-utils';

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
  
  viewDate: Date = new Date();

  events: CalendarEvent[] = [
    {
      title: 'Event 1',
      start: new Date('2023-12-16 10:00:00'),
      end: new Date('2023-12-16 11:00:00'),
      color: { ... colors['red'] },
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

  


  ngOnInit(): void {
    
    


  }
}
