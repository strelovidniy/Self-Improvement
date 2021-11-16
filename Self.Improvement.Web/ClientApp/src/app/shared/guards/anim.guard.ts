import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import TemplateService from '../services/template.service';

@Injectable({
    providedIn: 'root'
})
export default class AnimGuard implements CanDeactivate<unknown> {
    public constructor(
        private templateService: TemplateService
    ) {}

    public async canDeactivate(
        component: unknown,
        currentRoute: ActivatedRouteSnapshot,
        currentState: RouterStateSnapshot,
        nextState?: RouterStateSnapshot): Promise<boolean | UrlTree> {
        this.templateService.TurnLoaderOn();

        await new Promise(resolve => setTimeout(resolve, 500));

        return true;
    }
}
