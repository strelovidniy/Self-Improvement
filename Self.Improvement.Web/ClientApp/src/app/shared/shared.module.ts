import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from './material.module';

@NgModule({
    imports: [
        FormsModule,
        MaterialModule,
        CommonModule,
        RouterModule
    ],
    exports: [
        FormsModule,
        MaterialModule,
        CommonModule,
        RouterModule
    ]
})
export default class SharedModule { }
