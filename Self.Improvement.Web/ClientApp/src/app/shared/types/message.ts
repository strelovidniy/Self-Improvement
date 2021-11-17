import MessageStatus from './enums/message-status.enum';

export default class Message {
    public id: string;
    public text: string;
    public chatId: string;
    public telegramChatId: number;
    public fromBot: boolean;
    public date: Date;
    public status: MessageStatus;
}
