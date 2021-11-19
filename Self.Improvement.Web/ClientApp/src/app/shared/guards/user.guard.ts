import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import LoginService from '../services/login.service';
import UserRole from '../types/enums/user-role.enum';

@Injectable({
    providedIn: 'root'
})
export default class UserGuard implements CanActivate {
    public constructor (
        private loginService: LoginService,
        private router: Router
    ) { }

    public async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean | UrlTree> {
        const user = await this.loginService.getUser();

        if (!user) location.href = location.origin + '/api/v1/account/google-login';

        if (user.role === UserRole.User || user.role === UserRole.Master || user.role === UserRole.Admin) return true;

        this.router.navigate(['api/v1/google-login']);

        return false;
    }
}
