import { Component, Input, OnInit } from '@angular/core';
import { Property, PaginatedProperties } from '../../models/property.model';
import { PropertyService } from '../../services/property.service';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrl: './property-list.component.css'
})

export class PropertyListComponent {
  properties?: Property[];
  currentIndex = -1;
  // title = '';

  @Input() viewMode = false;

  @Input() currentProperty: Property = {
    id: '',
    name: '', 
    address: '',
    emailAddress: '', 
    dateOfRegistration: '', 
    price: 0
  };
  Math = Math;
  pageNumber = 1;
  pageSize = 5;
  totalItems = 0;

  constructor(private propertyService: PropertyService) { }

  ngOnInit(): void {
    this.retrievePropeties();
  }

  retrievePropeties(): void {
    this.propertyService
    .getAll(this.pageNumber, this.pageSize)
      .subscribe({
        next: (response: PaginatedProperties) => {
          //this.pagingResponse = data;
          this.properties = response.items;
          this.totalItems = response.totalCount
          console.log(response);
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

  onPageChange(newPage: number): void {
    this.pageNumber = newPage;
    this.retrievePropeties();
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
