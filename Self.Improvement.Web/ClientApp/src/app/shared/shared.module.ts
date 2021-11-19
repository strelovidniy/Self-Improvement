import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import ConfirmDialogComponent from './components/confirm-dialog/confirm-dialog.component';
import { GoalCardComponent } from './components/goal-card/goal-card.component';
import GoalEditorComponent from './components/goal-editor/goal-editor.component';

import MaterialModule from './material.module';

@NgModule({
    declarations: [
        ConfirmDialogComponent,
        GoalCardComponent,
        GoalEditorComponent
    ],
    imports: [
        FormsModule,
        MaterialModule,
        CommonModule,
        RouterModule,
        ReactiveFormsModule
    ],
    exports: [
        FormsModule,
        MaterialModule,
        CommonModule,
        RouterModule,
        ReactiveFormsModule
    ]
})
export default class SharedModule { }
