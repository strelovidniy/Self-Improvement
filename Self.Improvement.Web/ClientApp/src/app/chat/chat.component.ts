import { AfterViewInit, Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import TemplateService from '../shared/services/template.service';

@Component({
    selector: 'app-chat',
    templateUrl: './chat.component.html',
    styleUrls: ['./chat.component.css']
})
export default class ChatComponent implements AfterViewInit {

    public messages = [{ text: 'Hey', fromBot: true }, { text: 'Hey Hey Hey Hey Hey Hey Hey Hey Hey Hey Hey', fromBot: false }];

    public messageInputFormControl = new FormControl();

    public constructor(
        private templateService: TemplateService
    ) { }

    public ngAfterViewInit(): void {
        this.templateService.TurnLoaderOff();
    }

    public sendMessage(): void {
        if (this.messageInputFormControl.value) {
            const message = this.messageInputFormControl.value.trim();

            this.messageInputFormControl.reset();

            this.messages.push({
                text: message,
                fromBot: false,
            });
        } else {

        }
    }
}
