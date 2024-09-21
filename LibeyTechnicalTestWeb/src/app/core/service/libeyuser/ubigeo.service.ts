import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Ubigeo } from "src/app/entities/ubigeo";
@Injectable({
	providedIn: "root",
})
export class UbigeoService {
	constructor(private http: HttpClient) {}
	List(provinceCode:string,regionCode:string): Observable<Ubigeo[]> {
		const uri = `${environment.pathLibeyTechnicalTest}Ubigeo/${provinceCode}/${regionCode}`;
		return this.http.get<Ubigeo[]>(uri);
	}
}