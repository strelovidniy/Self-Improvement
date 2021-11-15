import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import AppComponent from './app.component';
import NavMenuComponent from './nav-menu/nav-menu.component';
import HomeComponent from './home/home.component';
import CounterComponent from './counter/counter.component';
import FetchDataComponent from './fetch-data/fetch-data.component';
import SharedModule from './shared/shared.module';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
        ], { relativeLinkResolution: 'legacy' }),
        SharedModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export default class AppModule { }
