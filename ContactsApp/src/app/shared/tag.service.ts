import { Injectable } from '@angular/core';
import { Tag } from './tag.model';
import { HttpClient } from "@angular/common/http";
declare var window:any;
@Injectable({
  providedIn: 'root'
})
export class TagService {
  tags: Tag[];
  tagModel: Tag = new Tag();
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
    this.tagModel = new Tag();
    this.addTagModal.show();
  }

  closeAddTagModal(){
    this.tagModel = new Tag();
    this.addTagModal.toggle();
  }

  readonly baseURL = "http://localhost:5297/api/Tag"


  getTags(){
    return this.http.get<Tag[]>(this.baseURL);
  }

  postTag(data:Tag){
    return this.http.post(this.baseURL,data);
  }

  deleteTag(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

 

  refreshTags(){
    this.getTags().subscribe((data:Tag[])=> {
      this.tags = data;
    });
  }
  
}
