import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";
@Injectable({
	providedIn: "root",
})
export class LibeyUserService {
	constructor(private http: HttpClient) {}
	Find(documentNumber: string): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.get<LibeyUser>(uri);
	}
	List(page: number,limit:number): Observable<LibeyUser[]> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/list?page=${page}&limit=${limit}`;
		return this.http.get<LibeyUser[]>(uri);
	}
	Save(user: LibeyUser): Observable<boolean> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
		return this.http.post<boolean>(uri,user);
	}
	Update(user: LibeyUser): Observable<boolean> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
		return this.http.put<boolean>(uri,user);
	}
	Delete(documentNumber: string): Observable<boolean> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.delete<boolean>(uri);
	}
}