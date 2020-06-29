import { IDog } from './IDog';

export interface IReport {
    id: number;
    dateReported: Date;
    contactEmail: string;
    contactNumber: string;
    dog: IDog;
}