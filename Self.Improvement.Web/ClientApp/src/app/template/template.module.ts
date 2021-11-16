import { NgModule } from '@angular/core';

import SharedModule from '../shared/shared.module';
import LoaderComponent from './loader/loader.component';
import TemplateComponent from './template.component';
import NavMenuComponent from './nav-menu/nav-menu.component';

@NgModule({
    declarations: [
        LoaderComponent,
        TemplateComponent,
        NavMenuComponent
    ],
    imports: [
        SharedModule,
    ],
    exports: [
        TemplateComponent
    ]
})
export default class TemplateModule { }
