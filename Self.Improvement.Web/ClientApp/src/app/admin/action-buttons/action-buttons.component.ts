import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
    selector: 'app-action-buttons',
    templateUrl: './action-buttons.component.html',
    styleUrls: ['./action-buttons.component.css']
})
export default class ActionButtonsComponent implements OnInit {

    @Output() private onDelete = new EventEmitter<void>();
    @Output() private onEdit = new EventEmitter<void>();

    public constructor() { }

    public ngOnInit(): void {
    }

    public onDeleteClick(): void {
        this.onDelete.emit();
    }

    public onEditClick(): void {
        this.onEdit.emit();
    }
}
