import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-invalid-fields',
    templateUrl: './invalid-fields.component.html',
    styleUrls: ['./invalid-fields.component.css']
})
export class InvalidFieldsComponent {
    @Input() invalidFields: string[];

    constructor() { }
}
