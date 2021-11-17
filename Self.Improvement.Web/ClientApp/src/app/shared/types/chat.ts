import ChatStatus from './enums/chat-status.enum';
import Message from './message';

export default class Chat {
    public id: string;
    public userId: string;
    public name: string;
    public telegramChatId: number;
    public hasUnreadMessages: boolean;
    public endDate: Date;
    public status: ChatStatus;
    public messages: Message[];
}
