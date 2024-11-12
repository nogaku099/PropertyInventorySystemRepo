import { Component, Input, OnInit } from '@angular/core';
import { Property } from '../../models/property.model';
import { PropertyService } from '../../services/property.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.css']
})
export class PropertyDetailsComponent implements OnInit {

  @Input() viewMode = false;

  @Input() currentProperty: Property = {
    id: '',
    name: '', 
    address: '',
    emailAddress: '', 
    dateOfRegistration: '', 
    price: 0
  };
  
  message = '';

  constructor(
    private propertyService: PropertyService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    if (!this.viewMode) {
      this.message = '';
      this.getProperty(this.route.snapshot.params["id"]);
    }
  }

  getProperty(id: string): void {
    this.propertyService.get(id)
      .subscribe({
        next: (data) => {
          this.currentProperty = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }

  updatePublished(status: boolean): void {
    const data = {
      name: this.currentProperty.name, 
      address: this.currentProperty.address,
      emailAddress: this.currentProperty.emailAddress, 
      dateOfRegistration: this.currentProperty.dateOfRegistration, 
      price: this.currentProperty.price
    };

    this.message = '';

    this.propertyService.update(this.currentProperty.id, data)
      .subscribe({
        next: (res) => {
          console.log(res);
          // this.currentProperty.published = status;
          this.message = res.message ? res.message : 'The status was updated successfully!';
        },
        error: (e) => console.error(e)
      });
  }

  updateProperty(): void {
    this.message = '';

    this.propertyService.update(this.currentProperty.id, this.currentProperty)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.message = res.message ? res.message : 'This property was updated successfully!';
        },
        error: (e) => console.error(e)
      });
  }

  deleteProperty(): void {
    this.propertyService.delete(this.currentProperty.id)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.router.navigate(['/properties']);
        },
        error: (e) => console.error(e)
      });
  }

}