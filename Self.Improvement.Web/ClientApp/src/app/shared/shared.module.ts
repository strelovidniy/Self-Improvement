import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import MaterialModule from './material.module';

@NgModule({
    imports: [
        FormsModule,
        MaterialModule,
        CommonModule,
        RouterModule,
        ReactiveFormsModule
    ],
    exports: [
        FormsModule,
        MaterialModule,
        CommonModule,
        RouterModule,
        ReactiveFormsModule
    ]
})
export default class SharedModule { }
