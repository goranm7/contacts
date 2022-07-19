import { Injectable } from '@angular/core';
import { TagDetail } from './tag-detail.model';
import { HttpClient } from "@angular/common/http";
declare var window:any;
@Injectable({
  providedIn: 'root'
})
export class TagDetailService {
  tags: TagDetail[];
  tagModel: TagDetail = new TagDetail();
  tagModal: any;
  addTagModal: any;
  constructor(private http: HttpClient) { }

  openTagModal(){
    this.tagModal.show();
  }

  closeTagModal(){
    this.tagModal.toggle();
  }

  openAddTagModal(){
    this.tagModel = new TagDetail();
    this.addTagModal.show();
  }

  closeAddTagModal(){
    this.tagModel = new TagDetail();
    this.addTagModal.toggle();
  }

  readonly baseURL = "http://localhost:5297/api/TagDetails"


  getTags(){
    return this.http.get<TagDetail[]>(this.baseURL);
  }

  postTag(data:TagDetail){
    return this.http.post(this.baseURL,data);
  }

  deleteTag(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

 

  refreshTags(){
    this.getTags().subscribe((data:TagDetail[])=> {
      this.tags = data;
    });
  }
  
}
