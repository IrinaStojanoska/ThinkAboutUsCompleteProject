import { Status, Gender } from './IDog';
import { IDogSize } from './IDogSize';

export interface ICreateDogDto {
    status: Status;
    code: string;
    sizeId: number,
    gender: Gender;
    location: string;
    breed: string;
    description: string;
    imageUrl: string;
}