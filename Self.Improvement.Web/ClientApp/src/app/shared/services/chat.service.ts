import { HttpClient } from '@angular/common/http';
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
        return this.http.get<Chat[]>(`${this.endpointService.chatUrl}unread`).toPromise();
    }

    public async getReadChats(): Promise<Chat[]> {
        return this.http.get<Chat[]>(`${this.endpointService.chatUrl}read`).toPromise();
    }

    public async getChatById(chatId: string): Promise<Chat> {
        return this.http.get<Chat>(`${this.endpointService.chatUrl}${chatId}`).toPromise();
    }
}
