import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import SharedModule from '../shared/shared.module';
import AnimGuard from '../shared/guards/anim.guard';
import AdminComponent from './admin.component';
import ActionButtonsComponent from './action-buttons/action-buttons.component';
import AdminEditorComponent from './admin-editor/admin-editor.component';
import AdminGuard from '../shared/guards/admin.guard';

@NgModule({
    declarations: [
        AdminComponent,
        ActionButtonsComponent,
        AdminEditorComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: '', component: AdminComponent, pathMatch: 'full', canActivate: [AdminGuard], canDeactivate: [AnimGuard] },
        ]),
    ]
})
export default class AdminModule { }
