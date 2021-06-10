import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from '../Models/Categoria';

const httpOptions = {
  headers: new HttpHeaders ({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class CategoriasService {

  url: string = 'api/categoria';

  constructor(private http: HttpClient) { }

  GetAll(): Observable<Categoria[]>
  {
    return this.http.get<Categoria[]>(this.url);
  }
  GetCategoriaByID(id:number): Observable<Categoria>
  {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<Categoria>(apiUrl);
  }
  AddCategoria(categoria: Categoria): Observable<any>
  {
    console.log(categoria)
    return this.http.post<Categoria>(this.url,categoria,httpOptions);
  }
  UpdateCategoria(id :number, categoria: Categoria) :Observable<any>
  {
    const apiUrl = `${this.url}/${id}`;
    return this.http.put<Categoria>(apiUrl,categoria,httpOptions);
  }
  DeleteCategoria (id :number) :Observable<any>
  {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl,httpOptions);
  }
  FilterCategorias (nomeCategoria :string) : Observable<Categoria[]>
  {
    const apiUrl = `${this.url}/FilterCategoria/${nomeCategoria}`;
    return this.http.get<Categoria[]>(apiUrl);

  }

}
