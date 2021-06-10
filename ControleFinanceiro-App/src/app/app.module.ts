import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {TiposService} from '../app/Services/tipos.service';
import {CategoriasService} from '../app/Services/categorias.service';
import {HttpClientModule} from '@angular/common/http';
import { ListCategoriasComponent,DialogDeleteCategoriasComponent } from './Components/Categoria/list-categorias/list-categorias.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { NewCategoriaComponent } from './Components/Categoria/new-categoria/new-categoria.component';
import {ReactiveFormsModule} from '@angular/forms';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDividerModule} from '@angular/material/divider';
import {MatSelectModule} from '@angular/material/select';
import {MatGridListModule} from '@angular/material/grid-list';
import { UpdateCategoriaComponent } from './Components/Categoria/update-categoria/update-categoria.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatAutocompleteModule} from '@angular/material/autocomplete';






@NgModule({
  declarations: [
    AppComponent,
    ListCategoriasComponent,
    NewCategoriaComponent,
    UpdateCategoriaComponent,
    DialogDeleteCategoriasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatDividerModule,
    MatSelectModule,
    MatGridListModule,
    MatDialogModule,
    FormsModule,
    MatAutocompleteModule
  ],
  providers: [
    TiposService,
    CategoriasService,
    HttpClientModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
