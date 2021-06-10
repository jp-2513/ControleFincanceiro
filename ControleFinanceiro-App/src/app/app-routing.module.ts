import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ListCategoriasComponent} from '../app/Components/Categoria/list-categorias/list-categorias.component';
import { NewCategoriaComponent } from './Components/Categoria/new-categoria/new-categoria.component';
import { UpdateCategoriaComponent } from './Components/Categoria/update-categoria/update-categoria.component';

const routes: Routes = [
  {
  path : 'categorias/listcategorias',component: ListCategoriasComponent
  },
  {
    path : 'categorias/newcategoria',component: NewCategoriaComponent
  },
  {
    path : 'categorias/updatecategoria/:id',component: UpdateCategoriaComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
