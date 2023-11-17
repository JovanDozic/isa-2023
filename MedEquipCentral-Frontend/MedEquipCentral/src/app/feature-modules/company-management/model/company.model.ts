export interface Company {
    id: number;
    name: string;
    locationId: number;
    location: {
        id: number;
        latitude: number;
        longitude: number;
        street: string;
        streetNumber: string;
        city: string;
        zip: string;
        country: string;
    };
    description: string;
    rating: number;
}