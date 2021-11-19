import { AfterViewInit, Component } from '@angular/core';
import TemplateService from '../shared/services/template.service';
import AdminService from '../shared/services/admin.service';
import User from '../shared/types/user';
import UserRole from '../shared/types/enums/user-role.enum';
import { MatDialog } from '@angular/material/dialog';
import AdminEditorComponent from './admin-editor/admin-editor.component';
import ConfirmDialogComponent from '../shared/components/confirm-dialog/confirm-dialog.component';

@Component({
    selector: 'app-admin',
    templateUrl: './admin.component.html',
    styleUrls: ['./admin.component.css']
})
export default class AdminComponent implements AfterViewInit {
    public displayedColumns: string[] = ['id', 'name', 'email', 'role', 'actions'];

    public users: User[];

    public constructor(
        private templateService: TemplateService,
        private adminService: AdminService,
        private dialog: MatDialog
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        await this.getData();

        this.templateService.TurnLoaderOff();
    }

    public getUserRoleName = (role: UserRole): string => UserRole[role];

    public async addUser(): Promise<User> {
        const newUser: User = await this.dialog.open(AdminEditorComponent, {
            width: '500px',
            data: { edit: false }
        }).afterClosed().toPromise();

        if (newUser) {
            await this.adminService.addUser(newUser);

            await this.getData();
        }

        return newUser;
    }

    public async editUser(user: User): Promise<User> {
        const updatedUser: User = await this.dialog.open(AdminEditorComponent, {
            width: '500px',
            data: { edit: true, user: user }
        }).afterClosed().toPromise();

        if (updatedUser) {
            await this.adminService.updateUser(updatedUser);

            await this.getData();
        }

        return updatedUser;
    }

    public async deleteUser(user: User): Promise<boolean> {
        const answer: User = await this.dialog.open(ConfirmDialogComponent, {
            width: '250px',
            data: { text: 'Are you sure you want to delete this user?' }
        }).afterClosed().toPromise();

        if (answer) {
            const result = await this.adminService.removeUser(user);

            await this.getData();

            return result;
        }

        return false;
    }

    private async getData(): Promise<void> {
        this.users = await this.adminService.getUsers();
    }
}
