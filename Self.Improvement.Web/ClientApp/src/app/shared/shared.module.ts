import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';

@NgModule({
    imports: [
        HttpClientModule,
        FormsModule,
        BrowserAnimationsModule,
        MaterialModule,
    ],
    exports: [
        HttpClientModule,
        FormsModule,
        BrowserAnimationsModule,
        MaterialModule,
    ]
})
export default class SharedModule { }
