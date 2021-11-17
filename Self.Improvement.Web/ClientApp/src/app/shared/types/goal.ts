import GoalStatus from './enums/goal-status.enum';

export default class Goal {
    public id: string;
    public name: string;
    public userId: string;
    public description: string;
    public startDate: Date;
    public endDate: Date;
    public status: GoalStatus;
}
