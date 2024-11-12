export class Property {
    id?: string;
    name?: string;
    address?: string;
    dateOfRegistration?: string;
    emailAddress?: string;
    price?: number;
}

export interface PaginatedProperties {
    items: Property[];
    // Add any other pagination fields here if they exist, like:
    totalCount: number;
    totalPages: number;
    pageNumber: number;
    pageSize: number;
  }
