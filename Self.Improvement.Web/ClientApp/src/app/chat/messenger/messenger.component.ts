import { AfterViewInit, Component, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import TemplateService from '../../shared/services/template.service';
import * as signalR from '@microsoft/signalr';
import EndpointService from 'src/app/shared/services/endpoint.service';
import { ActivatedRoute } from '@angular/router';
import Message from 'src/app/shared/types/message';
import MessageStatus from 'src/app/shared/types/enums/message-status.enum';

@Component({
    selector: 'app-messenger',
    templateUrl: './messenger.component.html',
    styleUrls: ['./messenger.component.css']
})
export default class MessengerComponent implements AfterViewInit, OnDestroy {

    public messages = [{ text: 'Hey', fromBot: true }, { text: 'Hey Hey Hey Hey Hey Hey Hey Hey Hey Hey Hey', fromBot: false }];

    public messageInputFormControl = new FormControl();

    private chatId: string;

    private connection: signalR.HubConnection;

    public constructor(
        private templateService: TemplateService,
        private endpointService: EndpointService,
        private route: ActivatedRoute,
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        this.route.params.subscribe(params => this.chatId = params['chatId']);

        this.connection = new signalR.HubConnectionBuilder()
                .configureLogging(signalR.LogLevel.Information)
                .withUrl(`${this.endpointService.chatUrl}messages-hub`)
                .withAutomaticReconnect()
                .build();

        await this.connection.start();

        await this.invokeSignalR();

        this.connection.onreconnected(() => this.invokeSignalR());

        this.connection.on('RecieveMessage', (receivedMessage: any) => {
            this.messages.push(receivedMessage);
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
                    id: '015c7a74-9f2f-4299-a8a5-db010358b2f7',
                    status: MessageStatus.Read,
                    text: message,
                    telegramChatId: 234234234
                } as Message);
            }
        } else {

        }
    }

    private async invokeSignalR(): Promise<void> {
        await this.connection.invoke('EnterToGroup', this.chatId);
    }
}
