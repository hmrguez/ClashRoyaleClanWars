import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

export abstract class CrudService<T> {
    protected constructor(protected http: HttpClient, protected baseUrl: string) {}

    getAll(): Observable<T[]> {
        return this.http.get<T[]>(this.baseUrl);
    }

    getSingle(id: string | number): Observable<T> {
        const url = `${this.baseUrl}/${id}`;
        return this.http.get<T>(url);
    }

    create(item: T): Observable<T> {
        return this.http.post<T>(this.baseUrl, item);
    }

    update(id: string | number, item: T): Observable<T> {
        const url = `${this.baseUrl}/${id}`;
        return this.http.put<T>(url, item);
    }

    delete(id: string | number): Observable<void> {
        const url = `${this.baseUrl}/${id}`;
        return this.http.delete<void>(url);
    }
}
