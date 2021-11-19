import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import User from '../types/user';
import EndpointService from './endpoint.service';

@Injectable({
    providedIn: 'root'
})
export default class AdminService {

    public constructor(
        private endpointService: EndpointService,
        private http: HttpClient
    ) { }

    public getUsers(): Promise<User[]> {
        return this.http.get<User[]>(`${this.endpointService.adminUrl}users`).toPromise();
    }

    public addUser(user: User): Promise<User> {
        return this.http.post<User>(`${this.endpointService.adminUrl}users`, user).toPromise();
    }

    public updateUser(user: User): Promise<User> {
        return this.http.put<User>(`${this.endpointService.adminUrl}users`, user).toPromise();
    }

    public removeUser(user: User): Promise<boolean> {
        return this.http.delete<boolean>(`${this.endpointService.adminUrl}users/${user.id}`).toPromise();
    }
}
