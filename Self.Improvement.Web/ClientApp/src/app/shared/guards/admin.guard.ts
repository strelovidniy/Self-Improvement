import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import LoginService from '../services/login.service';
import UserRole from '../types/enums/user-role.enum';

@Injectable({
    providedIn: 'root'
})
export default class AdminGuard implements CanActivate {
    public constructor (
        private loginService: LoginService,
        private router: Router
    ) { }

    public async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean | UrlTree> {
        const user = await this.loginService.getUser();

        if (!user) this.loginService.login();

        if (user.role === UserRole.Admin) return true;

        this.router.navigate(['error/access-denied']);

        return false;
    }
}
