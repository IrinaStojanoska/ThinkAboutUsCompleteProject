import { ICreateDogDto } from './ICreateDogDto';

export interface ICreateReportDto {
    contactNumber: string;
    contactEmail: string;
    dog: ICreateDogDto;
}