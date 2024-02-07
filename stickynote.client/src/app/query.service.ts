import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {StickyNote} from "./StickyNote";

@Injectable({
  providedIn: 'root'
})
export class QueryService {
  host = "http://localhost:5120/"
  private stickNotes: StickyNote[] = [];
  constructor(private http: HttpClient) {
    this.GetAllStickyNotes();
  }
Allnotes(): StickyNote[]{
    return  this.stickNotes;
}
  GetAllStickyNotes():void{
    this.stickNotes.length = 0;

    this.http.get<StickyNote[]>(this.host+"all").subscribe({
      next: values =>{
        values.forEach(item=>this.stickNotes.push(item))
      }
    });
  }
  Create(note: StickyNote):void{
    this.http.put(this.host+"StickyNote",note).subscribe(res=>{
   console.log(res);
   this.GetAllStickyNotes()
    })
  }
  Delete(id:string){
        this.http.delete(this.host+"StickyNote?id="+id).subscribe( res=>{
          console.log(res)
    this.GetAllStickyNotes()
        }

  )
  }
  Update(note: StickyNote){
    this.http.patch(this.host+"StickyNote",note).subscribe(res=>{
      this.GetAllStickyNotes()
    })

  }
}
