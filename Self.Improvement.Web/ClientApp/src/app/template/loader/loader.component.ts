import { Component, EventEmitter, Output } from '@angular/core';

@Component({
    selector: 'app-loader',
    templateUrl: './loader.component.html',
    styleUrls: ['./loader.component.css']
})
export default class LoaderComponent {
    @Output() private loaded = new EventEmitter();

    private progress: number;

    public visible: boolean;

    public getProgress(): number {
        if (this.progress < 100) {
            this.progress += 4;
        } else {
            this.fadeOut();
        }

        return this.visible ? this.progress : 0;
    }

    public ngOnInit(): void {
        this.progress = 0;
    }

    public async ngAfterViewInit(): Promise<void> {
        await this.fadeIn();
    }

    public async fadeIn(): Promise<void> {
        document.getElementById('loader-wrapper').style.opacity = '1';

        await new Promise(resolve => setTimeout(resolve, 500));

        this.visible = true;
    }

    public fadeOut(): void {
        this.visible = false;

        document.getElementById('loader-wrapper').style.opacity = '0';
        this.loaded.emit();
    }
}
