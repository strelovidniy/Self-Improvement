import { NgModule } from '@angular/core';

import SharedModule from '../shared/shared.module';
import LoaderComponent from './loader/loader.component';
import TemplateComponent from './template.component';

@NgModule({
    declarations: [
        LoaderComponent,
        TemplateComponent
    ],
    imports: [
        SharedModule,
    ],
    exports: [
        TemplateComponent
    ]
})
export default class TemplateModule { }
