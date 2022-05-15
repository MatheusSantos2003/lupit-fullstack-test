import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import ResponseModel from '../models/ResponseModel';
import Time from '../models/Time.model';

@Injectable({
  providedIn: 'root'
})
export class TimesService {
  private apiUrl = "http://localhost:2797/api";
  constructor(private http: HttpClient) { }

  public ListarTimes() {
    return this.http.get<ResponseModel<Time[]>>(`${this.apiUrl}/Times/ListarTimes`)
      .pipe(
        map((response) => {
          return response;
        })
      );
  }

  public CadastrarTime(time:Time){
    return this.http.post<ResponseModel<any>>(`${this.apiUrl}/Times/AdicionarTime`,time)
    .pipe(
      map((response)=>{
        return response;
      })
    )
  }


}
