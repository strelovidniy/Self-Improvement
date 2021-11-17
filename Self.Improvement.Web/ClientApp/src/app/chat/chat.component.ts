import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import ChatService from '../shared/services/chat.service';
import TemplateService from '../shared/services/template.service';
import Chat from '../shared/types/Chat';
import ChatStatus from '../shared/types/enums/chat-status.enum';

@Component({
    selector: 'app-chat',
    templateUrl: './chat.component.html',
    styleUrls: ['./chat.component.css']
})
export default class ChatComponent implements OnInit, AfterViewInit {

    public chats: Chat[] = [
        {
            endDate: new Date(),
            hasUnreadMessages: true,
            id: '0000-0000-000000-000-000000',
            messages: [],
            name: 'Chat 1',
            status: ChatStatus.Active,
            telegramChatId: 0,
            userId: ''
        },

        {
            endDate: new Date(),
            hasUnreadMessages: false,
            id: '',
            messages: [],
            name: 'Chat 1',
            status: ChatStatus.Active,
            telegramChatId: 0,
            userId: ''
        }
    ];

    public constructor(
        private templateService: TemplateService,
        private chatService: ChatService,
        private router: Router
    ) { }

    public ngOnInit(): void {

    }

    public async ngAfterViewInit(): Promise<void> {
        this.chats = (await this.chatService.getUnreadChats()) || [];
        this.chats.push(...((await this.chatService.getReadChats()) || []));
        this.templateService.TurnLoaderOff();
    }

    public onChatCardClick(chat: Chat): void {
        this.router.navigate([`/chat/${chat.id}`]);
    }
}
