import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/internal/Subject';

@Injectable({
    providedIn: 'root'
})
export default class TemplateService {
    public loaded = new Subject<void>();
    public started = new Subject<void>();

    public TurnLoaderOff(): void {
        this.loaded.next();
    }

    public TurnLoaderOn(): void {
        this.started.next();
    }
}
