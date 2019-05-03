import { ListItem } from './list-item';

export class List {
  id: number;
  ownerId: number;
  santaId: number;
  groupId: number;
  name: string;
  isPrimary: boolean;
  items: ListItem[];
}
