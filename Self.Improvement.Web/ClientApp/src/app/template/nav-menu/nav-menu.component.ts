import { Component, OnInit } from '@angular/core';
import LoginService from 'src/app/shared/services/login.service';
import UserRole from 'src/app/shared/types/enums/user-role.enum';
import INavPage from 'src/app/shared/types/interfaces/nav-page.interface';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export default class NavMenuComponent implements OnInit {
    public pages: INavPage[] = [];

    public constructor (
        private loginService: LoginService
    ) { }

    public async ngOnInit(): Promise<void> {
        const user = await this.loginService.getUser();

        this.pages.push({
            name: 'Home',
            routerLink: '/'
        });
        this.pages.push({
            name: 'Dashboard',
            routerLink: '/dashboard'
        });

        if (user.role === UserRole.Admin || user.role == UserRole.Master) {
            this.pages.push({
                name: 'Chat',
                routerLink: '/chat'
            });
        }

        if (user.role === UserRole.Admin) {
            this.pages.push({
                name: 'Admin',
                routerLink: '/admin'
            });
        }
    }
}
