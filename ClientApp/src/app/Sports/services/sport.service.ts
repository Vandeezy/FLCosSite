import { Injectable } from '@angular/core';
import {AddSport} from '../models/addSport.model';
import {EditSport} from '../models/editSport.model';
import {Sport} from '../models/sport.model';
import {DeleteSports} from '../models/deleteSports.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class SportService {

  constructor(private http: HttpClient) { }
  private url = "api/sports";
  addSport(model: AddSport): Observable<any> {
    const url = `${this.url}`;
    return this.http.post<any>(url, model, httpOptions);
  }
  getSport(id: number): Observable<Sport>{
    const url = `${this.url}/${id}`;
    return this.http.get<Sport>(url);
  }
  editSport(id: number, model: EditSport): Observable<any> {
    const url = `${this.url}/${id}`;
    return this.http.put<any>(url, model, httpOptions);
  }
  getUrl(query: string, startDate :string, endDate: string, page: number, pageSize: number){
    return `${this.url}/?query=${query}&startDate=${startDate}&endDate=${endDate}&page=${page}&pageSize=${pageSize}`;
  }
  getSports(query?: string, startDate? :string, endDate?: string, page?: number, pageSize?: number): Observable<Sport[]>{
    const url = this.getUrl(query, startDate, endDate, page, pageSize);
    // const url = `${this.url}/?query=${query}&startDate=${startDate}&endDate=${endDate}&page=${page}&pageSize=${pageSize}`;
    return this.http.get<any>(url);
  }
  deleteSport(id: number): Observable<any> {
    const url = `${this.url}/${id}`;
    return this.http.delete(url);
  }
  deleteSports(model: DeleteSports): Observable<any> {
    const url = `${this.url}/deletelist`;
    return this.http.post(url,model, httpOptions );
  }
}
