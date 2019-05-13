import { ListItem } from './list-item';

export class List {
  Id: number;
  OwnerId: number;
  SantaId: number;
  GroupId: number;
  Name: string;
  IsPrimary: boolean;
  Items: ListItem[];
}
