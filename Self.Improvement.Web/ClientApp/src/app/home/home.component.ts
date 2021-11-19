import { AfterViewInit, Component } from '@angular/core';
import GoalService from '../shared/services/goal.service';
import LoginService from '../shared/services/login.service';
import TemplateService from '../shared/services/template.service';
import Goal from '../shared/types/goal';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export default class HomeComponent implements AfterViewInit {
    public goals: Goal[] = [];

    public constructor(
        private templateService: TemplateService,
        private loginSerice: LoginService,
        private goalService: GoalService
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        const user = await this.loginSerice.getUser();

        if (user) {
            this.goals = await this.goalService.getActiveGoalsByUserId(user.id);
        } else {
            this.loginSerice.login();
        }

        this.templateService.TurnLoaderOff();
    }

    public async addGoal(): Promise<void> {

    }
}
