// import { HttpClient } from '@angular/common/http';
// import { Component, OnInit } from '@angular/core';
// import { event } from 'src/app/models/event.model';
// import { EventService } from 'src/app/services/event.service';

// export interface Event {
//   id: number;
//   basversion: string;
//   eventNo: any; 
//   eMinute?:string;
//   title?: string;
//   description?: string;
//   published?: boolean;
//   clientName?:any[];
//   ampm?:string;
//   bastimestamp?:Date;
//   time?:any;
//   occurrenceDate?:any;
//   eventType?:string;
//   hangName?:string;
//   jobLocationType?:string;
//   EventTypeText?:any;
//   EventDescription?:any;

// }
// @Component({
//   selector: 'app-event',
//   templateUrl: './event.component.html',
//   styleUrls: ['./event.component.css']
// })
// export class EventComponent implements OnInit {
//   eventTitles: string[] = [];
//   selectedEventType: string = '';
//   selectedworksitetype: string = '';
//   selectedorganization: string = '';
//   selectedtimezone:string='';
//   selectedreportinggroup:string='';
//   selectedregion:string='';
//   eventNames:string[]=[];
//   eventNamess:string[]=[];
//   eventNamesss:string[]=[];
//   eventNamessss:string[]=[];
//   eventNamesssss:string[]=[];
//   eventsList: Event[] = [];
//   eventData: Event = {} as Event;
//   submitted = false;
//   showFirstLastButtons: boolean = false;
//   nextId!: number;
//   constructor(private http: HttpClient, private eventService: EventService) {}

//   getEvent(): void {
//     const apiUrl = 'https://localhost:44343/api/Event';
//     this.http.get<Event[]>(apiUrl).subscribe({
//       next: (data) => {
//         this.eventsList = data;
//         console.log('Events loaded successfully:', data);
//       },
//       error: (error) => {
//         console.error('Error loading events:', error);
//       }
//     });
//   }
//   getEventTypeOptions(): void {
//     const apiUrl = 'https://localhost:44343/api/Event'; 
//     this.http.get<Event[]>(apiUrl).subscribe(
//       (data) => {
        
//         this.eventData.eventNo = data.map(event => event.eventNo);
//         console.log('eventNo loaded successfully:', this.eventData.eventNo);
//       },
//       (error) => {
//         console.error('Error loading eventNo:', error);
//       }
//     );
//   }

 

//   getEventTitles(): void {
//     const apiUrl = 'https://localhost:44343/api/Event/GetEventtypeTitles';

//     this.http.get<string[]>(apiUrl).subscribe(
//       (titles) => {
//         this.eventTitles = titles;
//       },
      
//       (error: any) => {
//         console.error('Error fetching event titles:', error);
//       }
//     );
//     }



//     getworksitetype(): void {
//       const apiUrl = 'https://localhost:44343/api/Event/worksitetype';
  
//       this.http.get<string[]>(apiUrl).subscribe(
//         (Names) => {
//           this.eventNames = Names;
//         },
        
//         (error: any) => {
//           console.error('Error fetching event titles:', error);
//         }
//       );
//       }



//       getorganization(): void {
//         const apiUrl = 'https://localhost:44343/api/Event/organization';
    
//         this.http.get<string[]>(apiUrl).subscribe(
//           (Names) => {
//             this.eventNamess = Names;
//           },
          
//           (error: any) => {
//             console.error('Error fetching event titles:', error);
//           }
//         );
//         }







//         gettimezone(): void {
//           const apiUrl = 'https://localhost:44343/api/Event/timezone';
      
//           this.http.get<string[]>(apiUrl).subscribe(
//             (Names) => {
//               this.eventNamesss = Names;
//             },
            
//             (error: any) => {
//               console.error('Error fetching event titles:', error);
//             }
//           );
//           }






//           getreportinggroup(): void {
//             const apiUrl = 'https://localhost:44343/api/Event/reportinggroup';
        
//             this.http.get<string[]>(apiUrl).subscribe(
//               (Names) => {
//                 this.eventNamessss = Names;
//               },
              
//               (error: any) => {
//                 console.error('Error fetching event titles:', error);
//               }
//             );
//             }




//             getregion(): void {
//               const apiUrl = 'https://localhost:44343/api/Event/region';
          
//               this.http.get<string[]>(apiUrl).subscribe(
//                 (Names) => {
//                   this.eventNamesssss = Names;
//                 },
                
//                 (error: any) => {
//                   console.error('Error fetching event titles:', error);
//                 }
//               );
//               }
  









//   saveEvent(): void {
//     const apiUrl = 'https://localhost:44343/api/Event';
//     this.eventService.getNextId().subscribe((nextId) => {
//       const eventDataWithId = {
//         Id: nextId,
//         ...this.eventData,
//       };

//       this.http.post(apiUrl, eventDataWithId).subscribe(
//         (data: event) => {
//           console.log('Event submitted successfully:', data);
//           this.submitted = true;
//           this.getEvent();
//         },
//         (error) => {
//           console.error('Error submitting event:', error);
//         }
//       );
//     });
//   }

//   ngOnInit(): void {
//     this.eventService.getNextId().subscribe((id) => {
//       this.nextId = id;
//     });
//   }
//   newEvent(): void {
//     this.eventData = {} as Event;
//     this.submitted = false;
//     this.getEvent(); 
//     this.getEventTypeOptions();
//     this.saveEvent();
//     this.getEventTitles();
//     this.getworksitetype();
//     this.getorganization();
//     this.gettimezone();
//     this.getreportinggroup();
//     this.getregion();
//   }
// }
























// event.component.ts
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EventService } from 'src/app/services/event.service';
import { ActivatedRoute, Router } from '@angular/router';

interface Event {
  id: number;
  basversion: number;



 
    eventNo: any; 
    eMinute?:string;
    title?: string;
    description?: string;
    published?: boolean;
    clientName?:any[];
    ampm?:string;
    bastimestamp?:Date;
    time?:any;
    occurrenceDate?:any;
    eventType?:string;
    hangName?:string;
    jobLocationType?:string;
    EventTypeText?:any;
    EventDescription?:any;
  // Add other properties as needed
}

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {

  eventTypes: string[] = [];
  selectedEventType: string = '';

  worksiteTypes: string[] = [];
  selectedWorksiteType: string = '';

  eventsList: Event[] = [];
  submitted = false;
  eventData: Event = {} as Event;

  constructor(private route:ActivatedRoute,private router:Router,   private http: HttpClient, private eventService: EventService) {
this.router.routeReuseStrategy.shouldReuseRoute=()=>false;


  }

  ngOnInit(): void {
    this.fetchDropdownData();
    this.getEvent();

  }

  fetchDropdownData(): void {
    this.getEventTypes();
    this.getWorksiteTypes();
  }



  





  getEventTypes(): void {
    const apiUrl = 'https://localhost:44343/api/Event/GetEventtypeTitles';

    this.http.get<string[]>(apiUrl).subscribe(
      (types) => {
        this.eventTypes = types;
      },
      (error: any) => {
        console.error('Error fetching event types:', error);
      }
    );
  }

  getWorksiteTypes(): void {
    const apiUrl = 'https://localhost:44343/api/Event/worksitetype';

    this.http.get<string[]>(apiUrl).subscribe(
      (types) => {
        this.worksiteTypes = types;
      },
      (error: any) => {
        console.error('Error fetching worksite types:', error);
      }
    );
  }
 
  
  getEvent(): void {
    const apiUrl = 'https://localhost:44343/api/Event';

    this.http.get<Event[]>(apiUrl).subscribe({
      next: (data) => {
        this.eventsList = data;
        console.log('Events loaded successfully:', data);
      },
      error: (error) => {
        console.error('Error loading events:', error);
      }
    });
  }

  saveEvent(): void {
    const apiUrl = 'https://localhost:44343/api/Event';
    this.eventService.getNextId().subscribe((nextId) => {
      this.eventData.id = nextId;

      this.http.post<Event>(apiUrl, this.eventData).subscribe(
        (data) => {
          console.log('Event submitted successfully:', data);
          this.submitted = true;
          this.getEvent();
        },
        (error) => {
          console.error('Error submitting event:', error);
        }
      );
    });
  }

  newEvent(): void {
    this.submitted = false;
    this.eventData = {} as Event;
  }
}
