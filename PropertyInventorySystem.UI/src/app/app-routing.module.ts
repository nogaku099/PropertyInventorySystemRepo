import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PropertyListComponent } from './components/property-list/property-list.component';
import { PropertyDetailsComponent } from './components/property-details/property-details.component';
import { AddPropertyComponent } from './components/add-property/add-property.component';
import { PropertiesContactComponent } from './components/propertycontact/propertycontact.component';

const routes: Routes = [
  { path: '', redirectTo: 'propertiesContacts', pathMatch: 'full' },
  { path: 'propertiesContacts', component: PropertiesContactComponent },
  { path: 'properties', component: PropertyListComponent },
  { path: 'property/:id', component: PropertyDetailsComponent },
  { path: 'add', component: AddPropertyComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
