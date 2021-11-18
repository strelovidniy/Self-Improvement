import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import AnimGuard from '../shared/guards/anim.guard';
import SharedModule from '../shared/shared.module';
import AccessDeniedComponent from './access-denied/access-denied.component';
import NotFoundComponent from './not-found/not-found.component';
import LoadingComponent from './loading/loading.component';

@NgModule({
    declarations: [
        AccessDeniedComponent,
        NotFoundComponent,
        LoadingComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: 'access-denied', component: AccessDeniedComponent, pathMatch: 'full', canDeactivate: [AnimGuard] },
            { path: 'loading', component: LoadingComponent, pathMatch: 'full', canDeactivate: [AnimGuard] },
            { path: 'not-found', component: NotFoundComponent, pathMatch: 'full', canDeactivate: [AnimGuard] },
            { path: '**', redirectTo: 'not-found' },
        ]),
    ]
})
export default class ErrorModule {}
