import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector: 'app-confirm-dialog',
    templateUrl: './confirm-dialog.component.html',
    styleUrls: ['./confirm-dialog.component.css']
})
export default class ConfirmDialogComponent implements OnInit {
    public text: string;

    public constructor(
        private dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: { text: string; },
    ) { }

    public ngOnInit(): void {
        this.text = this.data?.text;
    }

    public onYesClick(): void {
        this.dialogRef.close(true);
    }

    public onNoClick(): void {
        this.dialogRef.close(false);
    }
}
