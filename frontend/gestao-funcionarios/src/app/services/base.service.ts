import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { isNullOrUndefined } from 'util';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class BaseService {

  public constructor(private httpClient: HttpClient) { }

  public get(url, params = ''): Observable<any> {
    return this.httpClient.get(`${url}/${params}`)
      .pipe(map((result: any) => result));
  }

  public getById(url): Observable<any> {
    return this.httpClient.get(`${url}`)
      .pipe(map((result: any) => result));
  }

  public post(url, params): Observable<any> {
    return this.httpClient.post(`${url}/`, params)
      .pipe(map((result: any) => result));
  }

  public put(url, params): Observable<any> {
    return this.httpClient.put(`${url}/`, params)
      .pipe(map((result: any) => result));
  }

  public patch(url, params): Observable<any> {
    return this.httpClient.patch(`${url}/`, params)
      .pipe(map((result: any) => result));
  }

  public delete(url, params = ''): Observable<any> {
    return this.httpClient.delete(`${url}/${params}`)
      .pipe(map((result: any) => result));
  }

  protected createQueryString(parameters: any): string {
    let queryString = '';
    let colocarEComercial = false;

    for (const key in parameters) {
      if (parameters.hasOwnProperty(key)) {
        if (!isNullOrUndefined(parameters[key])) {
          if (colocarEComercial) {
            queryString += '&';
          }
          if (Array.isArray(parameters[key])) {
            parameters[key].forEach(element => {
              queryString += `${key}=${element}&`;
            });
          } else {
            queryString += key + '=' + parameters[key];
          }
          if (!colocarEComercial) {
            colocarEComercial = true;
          }
        }
      }
    }

    if (queryString !== '') {
      return '?' + queryString;
    }

    return '';
  }
}
