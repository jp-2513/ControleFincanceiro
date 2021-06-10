import { Component, OnInit } from '@angular/core';
import { Tipo } from 'src/app/Models/Tipo';
import {FormGroup,FormControl} from '@angular/forms';
import { TiposService } from 'src/app/Services/tipos.service';
import { CategoriasService } from 'src/app/Services/categorias.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-categoria',
  templateUrl: './new-categoria.component.html',
  styleUrls: ['../list-categorias/list-categorias.component.css']
})
export class NewCategoriaComponent implements OnInit {
form: any;
tipos: Tipo[] = [];

  constructor(private tiposService: TiposService , private categoriasService: CategoriasService, private router: Router) { }

  ngOnInit(): void {
    this.tiposService.GetAll().subscribe(result=> {
      this.tipos = result;
    });

    this.form = new FormGroup ({
      nome: new FormControl(null),
      icone: new FormControl(null),
      tipoId: new FormControl(null)
    });


  }

  get propriedade(){
    return this.form.controls;
  }

SendForm(): void {

    const categoria = this.form.value;

      this.categoriasService.AddCategoria(categoria).subscribe((result) =>{
      this.router.navigate(['categorias/listcategorias']);
    });
  }
  BackList(): void {
    this.router.navigate(['categorias/listcategorias'])
  }

}
