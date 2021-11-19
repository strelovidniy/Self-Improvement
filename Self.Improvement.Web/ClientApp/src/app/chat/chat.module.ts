import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import SharedModule from '../shared/shared.module';
import AnimGuard from '../shared/guards/anim.guard';
import ChatComponent from './chat.component';
import MessengerComponent from './messenger/messenger.component';
import MasterGuard from '../shared/guards/master.guard';

@NgModule({
    declarations: [
        ChatComponent,
        MessengerComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: '', component: ChatComponent, pathMatch: 'full', canActivate: [MasterGuard], canDeactivate: [AnimGuard] },
            { path: ':chatId', component: MessengerComponent, pathMatch: 'preffix', canActivate: [MasterGuard], canDeactivate: [AnimGuard] },
        ]),
    ]
})
export default class HomeModule { }
