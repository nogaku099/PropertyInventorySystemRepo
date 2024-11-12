import { Component, Input, OnInit } from '@angular/core';
import { Property, PaginatedProperties, PropertyContact } from '../../models/property.model';
import { PropertyService } from '../../services/property.service';
import { map } from "rxjs/operators"; 

@Component({
  selector: 'app-property-list',
  templateUrl: './propertycontact.component.html',
  styleUrl: './propertycontact.component.css'
})

export class PropertiesContactComponent {
  properties?: Property[];
  currentIndex = -1;
  // title = '';
  propertiesContacts?: PropertyContact[];

  @Input() viewMode = false;

  @Input() currentProperty: Property = {
    id: '',
    name: '', 
    address: '',
    emailAddress: '', 
    dateOfRegistration: '', 
    price: 0,
    contactProperties: []
  };

  @Input() currentPropertyContact: PropertyContact = {
    id: '',
    name: '', 
    askingPrice: 0,
    owner: '',
    dateOfPurchase: '',
    soldAtPriceEUR: 0,
    soldAtPriceUSD: 0
  };

  Math = Math;
  pageNumber = 1;
  pageSize = 5;
  totalItems = 0;

  constructor(private propertyService: PropertyService) { }

  ngOnInit(): void {
    this.retrievePropeties();
  }

  // retrievePropeties(): void {
  //   this.propertyService
  //   .getAll(this.pageNumber, this.pageSize)
  //     .subscribe({
  //       next: (response: PaginatedProperties) => {
  //         //this.pagingResponse = data;
  //         this.properties = response.items;
  //         this.totalItems = response.totalCount
  //         console.log(response);
  //       },
  //       error: (e) => console.error(e)
  //     });
  // }

  retrievePropeties(): void {
    this.propertyService
      .getAll(this.pageNumber, this.pageSize)
      .pipe(
        map((response: PaginatedProperties) => {
          // Transform `Property[]` into `PropertyContact[]`
          const propertyContacts: PropertyContact[] = response.items.flatMap(property => {
            if (!property.contactProperties || property.contactProperties.length === 0) {
              // Add a default PropertyContact if contactProperties is null or empty
              return [{
                id: property.id,
                name: property.name,
                askingPrice: property.price,
                owner: 'N/A', // Default or placeholder value
                dateOfPurchase: 'N/A', // Default or placeholder value
                soldAtPriceEUR: 0, // Default value for sold price in EUR
                soldAtPriceUSD: 0 // Default value for sold price in USD
              }];
            } else {
              // Map each contactProperties item to a PropertyContact
              return property.contactProperties.map(contact => ({
                id: property.id,
                name: property.name,
                askingPrice: property.price,
                owner: contact.fullName,
                dateOfPurchase: contact.effectiveFrom, // Adjust based on your data structure
                soldAtPriceEUR: contact.priceOfAcquisition || 0,
                soldAtPriceUSD: (contact.priceOfAcquisition || 0) * 1.08 // Example conversion
              }));
            }
          });
  
          return {
            items: response.items,
            totalCount: response.totalCount,
            propertyContacts
          };
        })
      )
      .subscribe({
        next: (data) => {
          this.properties = data.items;
          this.propertiesContacts = data.propertyContacts;
          this.totalItems = data.totalCount;
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
