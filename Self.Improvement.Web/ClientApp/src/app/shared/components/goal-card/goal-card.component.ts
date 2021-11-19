import { Component, Input, OnInit } from '@angular/core';
import Goal from '../../types/goal';

@Component({
    selector: 'app-goal-card',
    templateUrl: './goal-card.component.html',
    styleUrls: ['./goal-card.component.css']
})
export class GoalCardComponent implements OnInit {
    @Input() public goal: Goal;

    public constructor() { }

    public ngOnInit(): void {
    }

}
