import { Component, OnInit } from '@angular/core';
import { Property } from '../../models/property.model';
import { PropertyService } from '../../services/property.service';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrl: './add-property.component.css'
})
export class AddPropertyComponent implements OnInit {
  property: Property = {
    id: '',
    name: '',
    address: '',
    dateOfRegistration: '',
    emailAddress: '',
    price: 0
  };
  submitted = false;

  constructor(private propertyService: PropertyService) { }

  ngOnInit(): void {
  }

  saveProperty(): void {
    const data = {
      name: this.property.name,
      address: this.property.address,
      dateOfRegistration: this.property.dateOfRegistration,
      emailAddress: this.property.emailAddress,
      price: this.property.price
    };

    this.propertyService.create(data)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.submitted = true;
        },
        error: (e) => console.error(e)
      });
  }

  newProperty(): void {
    this.submitted = false;
    this.property = {
      id: '',
      name: '',
      address: '',
      dateOfRegistration: '',
      emailAddress: '',
      price: 0
    };
  }
}
