import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from './material.module';

@NgModule({
    imports: [
        FormsModule,
        MaterialModule,
    ],
    exports: [
        FormsModule,
        MaterialModule,
    ]
})
export default class SharedModule { }
