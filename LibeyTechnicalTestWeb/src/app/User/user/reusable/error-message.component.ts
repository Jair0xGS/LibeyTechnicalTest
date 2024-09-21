import { Component, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-error-message',
  template: `
    <div *ngIf="control.invalid && (control.dirty ||  control.touched)">
      <small *ngIf="control.errors?.['required']">Campo requerido</small>
      <small *ngIf="control.errors?.['minlength']">Ingrese mas caracteres.</small>
      <small *ngIf="control.errors?.['maxlength']">Ingrese menos caracteres.</small>
      <small *ngIf="control.errors?.['email']">Correo invalido.</small>
      <small *ngIf="control.errors?.['pattern']">Campo con formato invalido.</small>
      <small *ngIf="control.errors?.['lengthInvalid']">Tamaño invalido</small>
    </div>
  `
})
export class ErrorMessageComponent {
  @Input() control!: AbstractControl;
}
