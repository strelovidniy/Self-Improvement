import MessageStatus from './enums/message-status.enum';

export default class Message {
    public id: string;
    public text: string;
    public chatId: number;
    public fromBot: boolean;
    public date: Date;
    public userId: string;
    public status: MessageStatus;
}
