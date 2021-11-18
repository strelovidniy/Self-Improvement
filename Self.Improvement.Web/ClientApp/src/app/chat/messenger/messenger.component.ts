import { AfterViewInit, Component, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import TemplateService from '../../shared/services/template.service';
import * as signalR from '@microsoft/signalr';
import EndpointService from 'src/app/shared/services/endpoint.service';
import { ActivatedRoute } from '@angular/router';
import Message from 'src/app/shared/types/message';
import MessageStatus from 'src/app/shared/types/enums/message-status.enum';
import Chat from 'src/app/shared/types/Chat';
import ChatService from 'src/app/shared/services/chat.service';

@Component({
    selector: 'app-messenger',
    templateUrl: './messenger.component.html',
    styleUrls: ['./messenger.component.css']
})
export default class MessengerComponent implements AfterViewInit, OnDestroy {
    public chat: Chat;

    public messageInputFormControl = new FormControl();

    private chatId: string;

    private connection: signalR.HubConnection;

    public constructor(
        private templateService: TemplateService,
        private endpointService: EndpointService,
        private chatService: ChatService,
        private route: ActivatedRoute,
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        await new Promise<void>(resolve => {
            this.route.params.subscribe(params => {
                this.chatId = params['chatId'];
                resolve();
            });
        });

        this.chat = await this.chatService.getChatById(this.chatId);

        this.connection = new signalR.HubConnectionBuilder()
                .configureLogging(signalR.LogLevel.Information)
                .withUrl(`${this.endpointService.chatUrl}messages-hub`)
                .withAutomaticReconnect()
                .build();

        await this.connection.start();

        await this.invokeSignalR();

        this.connection.onreconnected(() => this.invokeSignalR());

        this.connection.on('RecieveMessage', (receivedMessage: any) => {
            this.chat?.messages?.push(receivedMessage);
        });

        this.templateService.TurnLoaderOff();
    }

    public async ngOnDestroy(): Promise<void> {
        await this.connection?.invoke('LeaveTheGroup', this.chatId);
        await this.connection.stop();
    }

    public sendMessage(): void {
        if (this.messageInputFormControl.value) {
            const message = this.messageInputFormControl?.value?.trim();

            this.messageInputFormControl.reset();

            if (message) {
                this.connection.invoke('SendMessageToGroup', {
                    chatId: this.chatId,
                    date: new Date(Date.now()),
                    fromBot: false,
                    id: '00000000-0000-0000-0000-000000000000',
                    status: MessageStatus.Read,
                    text: message,
                    telegramChatId: this.chat.telegramChatId
                } as Message);
            }
        } else {

        }
    }

    private async invokeSignalR(): Promise<void> {
        await this.connection.invoke('EnterToGroup', this.chatId);
    }
}
