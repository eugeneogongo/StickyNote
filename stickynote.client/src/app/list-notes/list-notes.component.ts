import {Component, OnInit} from '@angular/core';
import {QueryService} from "../query.service";
import {StickyNote} from "../StickyNote";
import {MatDialog} from "@angular/material/dialog";
import {EditdialogComponent} from "../editdialog/editdialog.component";

@Component({
  selector: 'app-list-notes',
  templateUrl: './list-notes.component.html',
  styleUrl: './list-notes.component.css'
})
export class ListNotesComponent implements  OnInit{
  allnotes: StickyNote[] = [];
constructor(private queryManager: QueryService,public dialog: MatDialog) {

}
  ngOnInit(): void {
    this.allnotes = this.queryManager.Allnotes();
    console.log(this.allnotes)    }

  shownote(note: StickyNote) {
    let dialogRef = this.dialog.open(EditdialogComponent, {
      width: '50vh',
      height: 'auto',
      position: {
        left: 'calc(50vw - 200px + 250px)'
      },
      data: note
    });
  }

  delete(id: string) {
    this.queryManager.Delete(id);
  }
}
