import { Type } from './type.model';

export class Category {
    id: number;
    name: string;
    icon: string;
    typeId: number;
    type: Type;
}
