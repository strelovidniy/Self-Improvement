import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export default class EndpointService {
    public readonly chatUrl = '/api/v1/chats/';
}
