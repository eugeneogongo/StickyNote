import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { AddNoteComponent } from './add-note/add-note.component';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from "@angular/material/button";
import {MatInputModule} from "@angular/material/input";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {CdkDragPlaceholder} from "@angular/cdk/drag-drop";
import { ListNotesComponent } from './list-notes/list-notes.component';
import {MatGridList} from "@angular/material/grid-list";
import {MatDivider} from "@angular/material/divider";
import {MatProgressBar} from "@angular/material/progress-bar";
import { EditdialogComponent } from './editdialog/editdialog.component';
import {MatIcon} from "@angular/material/icon";


@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent,
    AddNoteComponent,
    ListNotesComponent,
    EditdialogComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, MatCardModule, FormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule, CdkDragPlaceholder, MatGridList, MatDivider, MatProgressBar, ReactiveFormsModule, MatIcon,
  ],
  providers: [
    provideAnimationsAsync()
  ]
})
export class AppModule { }
