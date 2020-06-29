import { IDogSize } from './IDogSize';

export interface IDog {
    id: number;
    status: Status;
    code: string;
    size: IDogSize,
    gender: Gender;
    location: string;
    breed: string;
    description: string;
    imageUrl: string;
}

export enum Status {
    homeless = 0,
    lost = 1,
    pendingAdoption = 2,
    pendingFound = 3,
    adopted = 4,
    found = 5,
}
  
export enum Gender {
    male = 0,
    female = 1
}
