import { Email } from "./email.model";
import { Tag } from "./tag.model";
import { Telephone } from "./telephone.model";

export class Contact {
    id: number = 0;
    name: string= '';
    surname: string = '';
    nickname: string= '';
    address: string= '';
    tagId: number ;
    tag: Tag;
    emails: Email[];
    numbers: Telephone[];
}
