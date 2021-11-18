import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import ConfirmDialogComponent from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import UserRole from 'src/app/shared/types/enums/user-role.enum';
import User from 'src/app/shared/types/user';
import * as uuid from 'uuid';

@Component({
    selector: 'app-admin-editor',
    templateUrl: './admin-editor.component.html',
    styleUrls: ['./admin-editor.component.css']
})
export default class AdminEditorComponent implements OnInit {

    public userNameFormControl = new FormControl('', [
        Validators.required
    ]);

    public userRoleFormControl = new FormControl('', [
        Validators.required
    ]);

    public userTelegramIdFormControl = new FormControl('', [
        Validators.required
    ]);

    public userEmailFormControl = new FormControl('', [
        Validators.required,
        Validators.email
    ]);

    public userFormGroup = new FormGroup({
        email: this.userEmailFormControl,
        name: this.userNameFormControl,
        telegramId: this.userTelegramIdFormControl,
        role: this.userRoleFormControl,
    });

    public constructor(
        private dialogRef: MatDialogRef<ConfirmDialogComponent>,
        @Inject(MAT_DIALOG_DATA) private data: { edit: boolean; user: User; }
    ) { }

    public ngOnInit(): void {
        if (this.data.edit) {
            this.userNameFormControl.setValue(this.data.user.name, { emitEvent: true });
            this.userRoleFormControl.setValue(this.data.user.role, { emitEvent: true });
            this.userTelegramIdFormControl.setValue(this.data.user.telegramId, { emitEvent: true });
            this.userEmailFormControl.setValue(this.data.user.email, { emitEvent: true });
        }
    }

    public save(): void {
        if (this.userFormGroup.valid) {
            this.dialogRef.close(this.data.edit
                ? {
                    ...this.data.user,
                    name: this.userNameFormControl.value,
                    role: this.userRoleFormControl.value as UserRole,
                    telegramId: Number(this.userTelegramIdFormControl.value),
                    email: this.userEmailFormControl.value
                } as User
                : {
                    chat: null,
                    goals: [],
                    id: uuid.NIL,
                    name: this.userNameFormControl.value,
                    role: this.userRoleFormControl.value,
                    telegramId: Number(this.userTelegramIdFormControl.value),
                    email: this.userEmailFormControl.value
                } as User);
        }
    }

    public discard(): void {
        this.dialogRef.close(undefined);
    }
}
