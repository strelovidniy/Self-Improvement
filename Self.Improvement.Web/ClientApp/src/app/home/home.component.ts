import { AfterViewInit, Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import GoalEditorComponent from '../shared/components/goal-editor/goal-editor.component';
import GoalService from '../shared/services/goal.service';
import LoginService from '../shared/services/login.service';
import TemplateService from '../shared/services/template.service';
import Goal from '../shared/types/goal';
import User from '../shared/types/user';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export default class HomeComponent implements AfterViewInit {
    public goals: Goal[] = [];

    private user: User;

    public constructor(
        private templateService: TemplateService,
        private loginSerice: LoginService,
        private goalService: GoalService,
        private dialog: MatDialog
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        this.user = await this.loginSerice.getUser();

        if (this.user) {
            await this.loadData();
        } else {
            this.loginSerice.login();
        }

        this.templateService.TurnLoaderOff();
    }

    public async addGoal(): Promise<Goal> {
        const newGoal: Goal = await this.dialog.open(GoalEditorComponent, {
            width: '500px',
            data: { edit: false }
        }).afterClosed().toPromise();

        if (newGoal) {
            newGoal.userId = this.user.id;

            await this.goalService.addGoal(newGoal);

            await this.loadData();
        }

        return newGoal;
    }

    private async loadData (): Promise<void> {
        this.goals = await this.goalService.getActiveGoalsByUserId(this.user.id);
    }
}
