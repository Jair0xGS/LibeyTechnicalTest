import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Province } from "src/app/entities/province";
@Injectable({
	providedIn: "root",
})
export class ProvinceService {
	constructor(private http: HttpClient) {}
	List(regionCode:string): Observable<Province[]> {
		const uri = `${environment.pathLibeyTechnicalTest}Province/${regionCode}`;
		return this.http.get<Province[]>(uri);
	}
}