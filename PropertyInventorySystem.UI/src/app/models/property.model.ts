export class Property {
    id?: string;
    name?: string;
    address?: string;
    dateOfRegistration?: string;
    emailAddress?: string;
    price?: number;
    contactProperties?: ContactProperty[]
}
export class ContactProperty {
    fullName?: string;
    effectiveFrom?: string;
    priceOfAcquisition?: number;
}
export interface PaginatedProperties {
    items: Property[];
    // Add any other pagination fields here if they exist, like:
    totalCount: number;
    totalPages: number;
    pageNumber: number;
    pageSize: number;
}

export class PropertyContact {
    
    id?: string;
    name?: string;
    askingPrice?: number;
    owner?: string;
    dateOfPurchase?: string;
    soldAtPriceEUR?: number;
    soldAtPriceUSD?: number;
}

export interface PaginatedPropertiesContacts {
    items: PropertyContact[];
    // Add any other pagination fields here if they exist, like:
    totalCount: number;
    totalPages: number;
    pageNumber: number;
    pageSize: number;
}
