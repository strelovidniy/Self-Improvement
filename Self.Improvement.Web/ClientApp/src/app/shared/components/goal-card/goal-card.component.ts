import { Component, Input } from '@angular/core';
import GoalStatus from '../../types/enums/goal-status.enum';
import Goal from '../../types/goal';

@Component({
    selector: 'app-goal-card',
    templateUrl: './goal-card.component.html',
    styleUrls: ['./goal-card.component.css']
})
export class GoalCardComponent {
    @Input() public goal: Goal;

    public getValue(): number {
        if (this.goal.status == GoalStatus.Completed) return 100;
        if (this.goal.status == GoalStatus.Pending) return 0;

        const delta = new Date(this.goal.startDate).getTime() - new Date(Date.now()).getTime();
        const range = new Date(this.goal.startDate).getTime() - new Date(this.goal.endDate).getTime() - (1000 * 60 * 60 * 24);

        return delta / range * 100;
    }

    public removeGoal(): void {

    }

    public completeGoal(): void {

    }
}
