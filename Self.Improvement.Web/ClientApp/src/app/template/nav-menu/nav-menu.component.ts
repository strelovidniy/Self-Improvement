import { Component } from '@angular/core';
import INavPage from 'src/app/shared/types/nav-page.interface';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export default class NavMenuComponent {
    public pages: INavPage[] = [
        {
            name: 'Home',
            routerLink: '/'
        },
        {
            name: 'Dashboard',
            routerLink: '/dashboard'
        },
        {
            name: 'Chat',
            routerLink: '/chat'
        },
        {
            name: 'Page 4',
            routerLink: '/'
        },
        {
            name: 'Page 5',
            routerLink: '/'
        }];
}
