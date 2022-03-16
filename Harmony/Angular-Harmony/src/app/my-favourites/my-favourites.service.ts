import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { harmonyDTO } from './harmony.model';

@Injectable({
  providedIn: 'root'
})
export class MyFavouritesService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<harmonyDTO[]>{
    return this.httpClient.get<harmonyDTO[]>("https://localhost:44383/api/MyFavoritesAPI");
  }

  delete(id:number){
    return this.httpClient.delete(`https://localhost:44383/api/MyFavoritesAPI/${id}`);
  }

  filter(values:any): Observable<any>{
    const params = new HttpParams({fromObject:values});
    return this.httpClient.get<harmonyDTO[]>("https://localhost:44383/api/MyFavoritesAPI/filter", {params, observe: 'response'} );
  }

}
