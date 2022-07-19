import { EmailDetail } from "./email-detail.model";
import { TagDetail } from "./tag-detail.model";
import { TelephoneDetail } from "./telephone-detail.model";

export class ContactDetail {
    id: number = 0;
    name: string= '';
    surname: string = '';
    nickname: string= '';
    address: string= '';
    tagDetailId: number ;
    tagDetail: TagDetail;
    emails: EmailDetail[];
    numbers: TelephoneDetail[];
}
