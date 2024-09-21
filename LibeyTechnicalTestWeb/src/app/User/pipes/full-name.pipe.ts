import { Pipe, PipeTransform } from '@angular/core';
import { LibeyUser } from 'src/app/entities/libeyuser';

@Pipe({
  name: 'fullName'
})
export class FullNamePipe implements PipeTransform {
  transform(value:LibeyUser): string {
    if (!value) return '';
    return `${value.fathersLastName} ${value.mothersLastName}, ${value.name}`.trim();
  }
}