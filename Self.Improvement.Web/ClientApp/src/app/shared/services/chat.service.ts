import { HttpClient } from '@angular/common/http';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Injectable } from '@angular/core';
import Chat from '../types/Chat';
import EndpointService from './endpoint.service';

@Injectable({
    providedIn: 'root'
})
export default class ChatService {

    public constructor(
        private endpointService: EndpointService,
        private http: HttpClient
    ) { }

    public async getUnreadChats(): Promise<Chat[]> {
        return this.http.get<Chat[]>(`${this.endpointService.chatUrl}/unread`).toPromise();
    }

    public async getReadChats(): Promise<Chat[]> {
        return this.http.get<Chat[]>(`${this.endpointService.chatUrl}/read`).toPromise();
    }

    public async sendMessage(message: Message): Promise<Message> {
        return this.http.post<Message>(`${this.endpointService.chatUrl}/read`, message).toPromise();
    }
}
