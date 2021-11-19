import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export default class EndpointService {
    public readonly chatUrl = '/api/v1/chats/';
    public readonly adminUrl = '/api/v1/admin/';
    public readonly accountUrl = '/api/v1/account/';
}
