import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import AppComponent from './app.component';
import TemplateModule from './template/template.module';

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
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', loadChildren: (): any => import('./home/home.module').then(m => m.default), pathMatch: 'full' },
            { path: 'dashboard', loadChildren: (): any => import('./dashboard/dashboard.module').then(m => m.default), pathMatch: 'full' },
            { path: 'chat', loadChildren: (): any => import('./chat/chat.module').then(m => m.default), pathMatch: 'prefix' },
            { path: 'admin', loadChildren: (): any => import('./admin/admin.module').then(m => m.default), pathMatch: 'prefix' },
        ], { relativeLinkResolution: 'legacy', preloadingStrategy: PreloadAllModules })
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export default class AppModule { }
