import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule } from '@angular/router';

import AppComponent from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [
        HttpClientModule,
        BrowserAnimationsModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        RouterModule.forRoot([
            { path: '', loadChildren: (): any => import('./home/home.module').then(m => m.default), pathMatch: 'full' },
        ], { relativeLinkResolution: 'legacy', preloadingStrategy: PreloadAllModules })
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export default class AppModule { }
