import Chat from './Chat';
import UserRole from './enums/user-role.enum';
import Goal from './goal';

export default class User {
    public id: string;
    public name: string;
    public telegramId: number;
    public role: UserRole;
    public goals: Goal[];
    public chat: Chat;
}
