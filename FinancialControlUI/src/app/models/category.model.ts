import { Type } from './type.model';

export interface Category {
    id: number;
    name: string;
    icon: string;
    typeId: number;
    type: Type;
}
