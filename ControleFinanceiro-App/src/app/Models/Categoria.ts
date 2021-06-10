import { Tipo } from "./Tipo";

export class Categoria {
  id: number=0;
  nome: string="" ;
  icone: string ="";
  tipoId : number=0;
  tipo: Tipo = new Tipo;
}
