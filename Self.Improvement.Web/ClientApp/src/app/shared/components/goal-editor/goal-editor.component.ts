import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import ConfirmDialogComponent from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import * as uuid from 'uuid';
import Goal from '../../types/goal';

@Component({
    selector: 'app-goal-editor',
    templateUrl: './goal-editor.component.html',
    styleUrls: ['./goal-editor.component.css']
})
export default class GoalEditorComponent implements OnInit {

    public goalNameFormControl = new FormControl('', [
        Validators.required
    ]);

    public goalDescriptionFormControl = new FormControl('', [
        Validators.nullValidator
    ]);

    public goalStartDateFormControl = new FormControl('', [
        Validators.required
    ]);

    public goalEndDateFormControl = new FormControl('', [
        Validators.required,
    ]);

    public goalFormGroup = new FormGroup({
        email: this.goalEndDateFormControl,
        name: this.goalNameFormControl,
        telegramId: this.goalStartDateFormControl,
        role: this.goalDescriptionFormControl,
    });

    public constructor(
        private dialogRef: MatDialogRef<ConfirmDialogComponent>,
        @Inject(MAT_DIALOG_DATA) private data: { edit: boolean; goal: Goal; }
    ) { }

    public ngOnInit(): void {
        if (this.data.edit) {
            this.goalNameFormControl.setValue(this.data.goal.name, { emitEvent: true });
            this.goalDescriptionFormControl.setValue(this.data.goal.description, { emitEvent: true });
            this.goalStartDateFormControl.setValue(this.data.goal.startDate, { emitEvent: true });
            this.goalEndDateFormControl.setValue(this.data.goal.endDate, { emitEvent: true });
        }
    }

    public save(): void {
        if (this.goalFormGroup.valid) {
            this.dialogRef.close(this.data.edit
                ? {
                    ...this.data.goal,
                    name: this.goalNameFormControl.value,
                    description: this.goalDescriptionFormControl.value,
                    startDate: new Date(this.goalStartDateFormControl.value),
                    endDate: new Date(this.goalEndDateFormControl.value)
                } as Goal
                : {
                    id: uuid.NIL,
                    userId: uuid.NIL,
                    name: this.goalNameFormControl.value,
                    description: this.goalDescriptionFormControl.value,
                    startDate: new Date(this.goalStartDateFormControl.value),
                    endDate: new Date(this.goalEndDateFormControl.value)
                } as Goal);
        }
    }

    public discard(): void {
        this.dialogRef.close(undefined);
    }
}
