import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import AppComponent from './app.component';
import TemplateModule from './template/template.module';
import RequestsInteceptor from './shared/interceptors/requests.interceptor';
import LoginService from './shared/services/login.service';
import AnimGuard from './shared/guards/anim.guard';
import UserGuard from './shared/guards/user.guard';
import AdminGuard from './shared/guards/admin.guard';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        TemplateModule,
        HttpClientModule,
        BrowserAnimationsModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        RouterModule.forRoot([
            { path: '', redirectTo: '/home', pathMatch: 'full' },
            { path: 'home', loadChildren: (): any => import('./home/home.module').then(m => m.default), pathMatch: 'prefix' },
            { path: 'dashboard', loadChildren: (): any => import('./dashboard/dashboard.module').then(m => m.default), pathMatch: 'prefix' },
            { path: 'chat', loadChildren: (): any => import('./chat/chat.module').then(m => m.default), pathMatch: 'prefix' },
            { path: 'admin', loadChildren: (): any => import('./admin/admin.module').then(m => m.default), pathMatch: 'prefix' },
            { path: 'error', loadChildren: (): any => import('./error/error.module').then(m => m.default), pathMatch: 'prefix' },
            { path: '**', redirectTo: '/error/not-found' },
        ], { relativeLinkResolution: 'legacy', preloadingStrategy: PreloadAllModules })
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: RequestsInteceptor, multi: true },
        LoginService,
        AnimGuard,
        UserGuard,
        UserGuard,
        AdminGuard,
    ],
    bootstrap: [AppComponent]
})
export default class AppModule { }
