import { Component, Inject, OnInit } from '@angular/core';
import {CategoriasService} from '../../../Services/categorias.service';
import {MatTableDataSource} from '@angular/material/table';
import { inject } from '@angular/core/testing';
import {MatDialog,MAT_DIALOG_DATA} from '@angular/material/dialog'
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import {startWith,map} from 'rxjs/operators';

@Component({
  selector: 'app-list-categorias',
  templateUrl: './list-categorias.component.html',
  styleUrls: ['./list-categorias.component.css']
})
export class ListCategoriasComponent implements OnInit {

  categorias = new MatTableDataSource<any>();

  displayedColumns: string[] = [];

  autoCompleteInput= new FormControl();

  opcoesCategorias: string[] = [];

  nomesCategorias: Observable<string[]> = new Observable<string[]>();

  constructor(private categoriaService: CategoriasService, private dialog: MatDialog)  { }

  ngOnInit(): void {
    this.categoriaService.GetAll().subscribe(result => {
      result.forEach(categoria =>{
        this.opcoesCategorias.push(categoria.nome);
      });
      this.categorias.data = result;
    });

    this.nomesCategorias = this.autoCompleteInput.valueChanges.pipe(startWith(''),map(nome=> this.FilterNomes(nome)));

    this.displayedColumns = this.ExibirColunas();
  }
  ExibirColunas(): string[]{
    return ['nome','icone','tipo','acoes']
  }
  ShowDialog(categoriaId: any, nome: any):void {
    this.dialog.open(DialogDeleteCategoriasComponent, {
      data :{
        categoriaId: categoriaId,
        nome: nome
      }
    }).afterClosed().subscribe(result => {
      if(result === true)
      {
        this.categoriaService.GetAll().subscribe(dados=>{
        this.categorias.data = dados;
        });
        this.displayedColumns = this.ExibirColunas();
      }
    });
  }
  FilterNomes(nome: string) : string[]{
    if(nome.trim().length >=4)
    {
        this.categoriaService.FilterCategorias(nome.toLowerCase()).subscribe(result => {
        this.categorias.data = result;
      });
    }
    else
    {
      if(nome === '')
      {
        this.categoriaService.GetAll().subscribe(result =>
        {
          this.categorias.data = result;
        });
      }
    }

    return this.opcoesCategorias.filter((categoria)=>
    categoria.toLowerCase().includes(nome.toLowerCase())
    );

  }

}

@Component({
  selector: 'app-dialog-delete-categorias',
  templateUrl: 'dialog-delete-categorias.html'
})

export class DialogDeleteCategoriasComponent{
  constructor(@Inject (MAT_DIALOG_DATA) public dados: any , private categoriasService: CategoriasService){}

  DeleteCategoria(categoriaId:any): void {
    this.categoriasService.DeleteCategoria(categoriaId).subscribe(result => {

    });
  }

}
