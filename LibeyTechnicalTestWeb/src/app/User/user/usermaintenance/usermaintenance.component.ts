import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { RegionService } from 'src/app/core/service/libeyuser/region.service';
import { Region } from 'src/app/entities/region';
import { Province } from 'src/app/entities/province';
import { AbstractControl, FormBuilder, FormGroup,Validators } from '@angular/forms';
import { ProvinceService } from 'src/app/core/service/libeyuser/province.service';
import { DocumentTypeService } from 'src/app/core/service/libeyuser/documentType.service';
import { DocumentType } from 'src/app/entities/documentType';
import { UbigeoService } from 'src/app/core/service/libeyuser/ubigeo.service';
import { Ubigeo } from 'src/app/entities/ubigeo';
import { ActivatedRoute, Router } from '@angular/router';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {
  regions:Region[] = [];
  ubigeos:Ubigeo[] = [];
  docTypes:DocumentType[] = [];
  provinces: Province[] = []; // Replace 'any' with a more specific type
  form: FormGroup;
  userDocumentNumber :string|null=null;
  constructor(
    private regionService :RegionService,
    private provinceService :ProvinceService,
    private docTypService :DocumentTypeService,
    private ubiService :UbigeoService,
    private userService :LibeyUserService,
    private fb: FormBuilder,
    private router:Router,
    private route:ActivatedRoute
  ) {

      this.form = this.fb.group({
        documentNumber: ['', Validators.required],
        documentTypeId: [null, Validators.required],
        name: ['', [Validators.required, Validators.minLength(2)]],
        fathersLastName : ['', [Validators.required, Validators.minLength(2)]],
        mothersLastName : ['', [Validators.required, Validators.minLength(2)]],
        address : ['', [Validators.required, Validators.minLength(2)]],
        regionCode: [null, Validators.required],
        provinceCode: [null, Validators.required],
        ubigeoCode: [null, Validators.required],
        phone: ['', [Validators.required, Validators.pattern(/^\d{9}$/)]],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]]
      });
   }
  ngOnInit(): void {
    //load regions
    this.loadDocTypes()
    this.loadRegions()
    this.route.queryParams.subscribe(params=>{
      this.userDocumentNumber = params['documentNumber']
      if(this.userDocumentNumber && this.userDocumentNumber !=''){
        this.userService.Find(this.userDocumentNumber).subscribe(user=>{
          console.log("user here",user)
          if(user.documentNumber!=null && user.documentNumber!=''){
            this.form.patchValue({
              ...user
            })
            this.loadProvinces(user.regionCode)
            this.loadUbis(user.provinceCode,user.regionCode)
          }else{
            swal.fire("Oops!", "Usuario no encontrado.Crea uno!", "error");
          }
        })
      }
    })
  }
  
  loadRegions():void{
    this.regionService.List().subscribe( (data)=> this.regions=data)
  }
  loadProvinces(regionCode:string ):void{
    this.provinceService.List(regionCode).subscribe( (data)=> this.provinces=data)
  }
  loadDocTypes():void{
    this.docTypService.List().subscribe( (data)=> this.docTypes=data)
  }
  loadUbis(proviceCode:string,regionCode:string):void{
    this.ubiService.List(proviceCode,regionCode).subscribe( (data)=> this.ubigeos=data)
  }

  onRegionChange(region:Region): void {
    console.log('region changed')
    this.form.patchValue({provinceCode:null,ubigeoCode:null})
    this.provinces=[];
    this.ubigeos=[];
    if(region){
      this.loadProvinces(region.regionCode)
    }
  }
  onProvinceChange(province:Province): void {
    console.log('province changed')
    this.form.patchValue({ubigeoCode:null})
    this.ubigeos=[];
    if(province){
      this.loadUbis(province.provinceCode,province.regionCode)
    }
  }
  resetForm(){
    this.form.reset();
    this.provinces=[];
    this.ubigeos=[];
  }
  goBack(){
    this.router.navigate(['/user/card']); // Replace with your desired route
  }

  Submit(){
  if (this.form.valid) {
      let vl  =this.form.value
      console.log(vl); 
      if(this.userDocumentNumber !=null && this.userDocumentNumber != ''){
        this.userService.Update(vl).subscribe(data=>{
          if(data){
            swal.fire("Exito!", "Usuario actualizado exitosamente!", "success");
            this.router.navigate(['/user/list']); // Replace with your desired route
          }
        })
      }else{
        this.userService.Save(vl).subscribe(data=>{
          if(data){
            swal.fire("Exito!", "Usuario guardado exitosamente!", "success");
            this.router.navigate(['/user/list']); // Replace with your desired route
          }
        })
      }
    } else {
      swal.fire("Oops!", "Formulario invalido!", "error");
    }
  }
}