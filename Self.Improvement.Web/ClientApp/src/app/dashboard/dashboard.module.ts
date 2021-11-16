import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import AnimGuard from '../shared/guards/anim.guard';

import SharedModule from '../shared/shared.module';
import DashboardComponent from './dashboard.component';

@NgModule({
    declarations: [
        DashboardComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: '', component: DashboardComponent, pathMatch: 'full', canDeactivate: [AnimGuard] },
        ]),
    ]
})
export default class HomeModule { }
