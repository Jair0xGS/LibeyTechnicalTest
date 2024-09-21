import swal from 'sweetalert2';
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";
import { LibeyUser } from "src/app/entities/libeyuser";
@Component({
	selector: "app-usertable",
	templateUrl: "./usertable.component.html",
	styleUrls: ["./usertable.component.css"],
})
export class UsertableComponent implements OnInit {
	constructor( 
		private libeyUserService: LibeyUserService,
    private router:Router
	) {}
	users:LibeyUser[]=[];
	page=1;
	limit=5;
	ngOnInit(): void {
		this.loadUsers()
	}
	loadUsers(){
		this.libeyUserService.List(this.page,this.limit).subscribe(response => {
			if(response.length>0) this.users=response
		});
	}
	handleDelete(documentNumber :string){
		swal.fire({
			title: "Seguro?",
			text: "No podras revertir esto!",
			icon: "warning",
			showCancelButton: true,
			confirmButtonColor: "#3085d6",
			cancelButtonColor: "#d33",
			confirmButtonText: "Si, borralo!"
		}).then((result) => {
			if (result.isConfirmed) {
				this.libeyUserService.Delete(documentNumber).subscribe(response=>{
					if(response==true){
						this.loadUsers()
						swal.fire({
							title: "Borrado!",
							text: "El usuario se ha borrado.",
							icon: "success"
						});
					}
				})
			}
		});
	}
	handleEdit(documentNumber :string){
    this.router.navigate([`/user/maintenance`],{queryParams:{documentNumber}}); 
	}
	goBack(){
		if(this.page==1)return;
		this.page-=1;
		this.loadUsers();
	}
	goNext(){
		this.page+=1;
		this.loadUsers();
	}
}