import { Component, Input, OnInit } from '@angular/core';
import { Property } from '../../models/property.model';
import { PropertyService } from '../../services/property.service';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrl: './property-list.component.css'
})
export class PropertyListComponent {

  properties?: Property[];
  //currentProperty: Property = {};
  currentIndex = -1;
  title = '';

  @Input() viewMode = false;

  @Input() currentProperty: Property = {
    id: '',
    name: '', 
    address: '',
    emailAddress: '', 
    dateOfRegistration: '', 
    price: 0
  };

  constructor(private propertyService: PropertyService) { }

  ngOnInit(): void {
    this.retrievePropeties();
  }

  retrievePropeties(): void {
    this.propertyService
    .getAll()
      .subscribe({
        next: (data) => {
          this.properties = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }

  refreshList(): void {
    this.retrievePropeties();
    this.currentProperty = {};
    this.currentIndex = -1;
  }

  setActiveProperty(property: Property, index: number): void {
    this.currentProperty = property;
    this.currentIndex = index;
  }

  removeAllProperties(): void {
    this.propertyService.deleteAll()
      .subscribe({
        next: (res) => {
          console.log(res);
          this.refreshList();
        },
        error: (e) => console.error(e)
      });
  }

  // searchTitle(): void {
  //   this.currentProperty = {};
  //   this.currentIndex = -1;

  //   this.propertyService.findByTitle(this.title)
  //     .subscribe({
  //       next: (data) => {
  //         this.tutorials = data;
  //         console.log(data);
  //       },
  //       error: (e) => console.error(e)
  //     });
  // }

}
