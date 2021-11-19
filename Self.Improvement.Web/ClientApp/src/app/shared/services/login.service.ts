import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import User from '../types/user';
import EndpointService from './endpoint.service';

@Injectable({
    providedIn: 'root'
})
export default class LoginService {
    private user: User;

    public constructor(
        private endpointService: EndpointService,
        private http: HttpClient
    ) {
        this.getUser();
    }

    public async getUser(): Promise<User> {
        this.user = await this.http.get<User>(`${this.endpointService.accountUrl}current-user`).toPromise();

        return this.user;
    }

    public login(): void {
        location.assign(`${location.origin}/api/v1/account/google-login`);
    }
}
