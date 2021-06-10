import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/Models/Categoria';
import { Tipo } from 'src/app/Models/Tipo';
import { CategoriasService } from 'src/app/Services/categorias.service';
import { TiposService } from 'src/app/Services/tipos.service';

@Component({
  selector: 'app-update-categoria',
  templateUrl: './update-categoria.component.html',
  styleUrls: ['../list-categorias/list-categorias.component.css']
})
export class UpdateCategoriaComponent implements OnInit {

nomeCategoria: string="";
categoria : Observable<Categoria> = new Observable ;
categoriaId : number = 0;
tipos: Tipo[]=[];
form: any;

  constructor(private router: Router , private route: ActivatedRoute,private tipoService: TiposService,private categoriaService: CategoriasService) { }

  ngOnInit(): void {
    this.categoriaId = this.route.snapshot.params.id;
    this.tipoService.GetAll().subscribe(result=>{
    this.tipos = result;
    });

    this.categoriaService.GetCategoriaByID(this.categoriaId).subscribe(result =>{
      this.nomeCategoria = result.nome;
      this.form = new FormGroup ({
        id: new FormControl(result.id),
        nome: new FormControl(result.nome),
        icone: new FormControl(result.icone),
        tipoId: new FormControl(result.tipoId)
      });
    });
  }

get propriedade(){
  return this.form.controls;
}
SendFormulario(): void {
  const categoria = this.form.value;
  this.categoriaService.UpdateCategoria(this.categoriaId,categoria).subscribe(result =>{
  this.router.navigate(['categorias/listcategorias'])
 });
}
BackList(): void {
  this.router.navigate(['categorias/listcategorias'])
}

}
