import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  readonly ApiUrl: string = environment.url;

  constructor(private http: HttpClient) { }


  private getFullUrl(url: string){
    return this.ApiUrl + url;
  }

  
  get(url: string, id?: number | string): Observable<any>{
    if (id !== undefined) {
      url += '/' + id;
    }
    return this.http.get(this.getFullUrl(url));
  }

  post(url: string, data: object){
    return this.http.post(this.getFullUrl(url), data);
  }

  put(url: string, id: number | string, data: any): Observable<any> {
    return this.http.put(this.getFullUrl(url) + `/${id}`, data);
  }

  delete(url: string, id: number | string){
    return this.http.delete(this.getFullUrl(url) + `/${id}`);
  }
}
