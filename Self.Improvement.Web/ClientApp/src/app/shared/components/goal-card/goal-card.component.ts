import { Component, Input } from '@angular/core';
import Goal from '../../types/goal';

@Component({
    selector: 'app-goal-card',
    templateUrl: './goal-card.component.html',
    styleUrls: ['./goal-card.component.css']
})
export class GoalCardComponent {
    @Input() public goal: Goal;

    public getValue(): number {
        const delta = new Date(this.goal.startDate).getTime() - new Date(Date.now()).getTime();
        const range = new Date(this.goal.startDate).getTime() - new Date(this.goal.endDate).getTime();

        return delta / range * 100;
    }
}
