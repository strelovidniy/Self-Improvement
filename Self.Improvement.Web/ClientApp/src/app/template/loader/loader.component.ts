import { AfterViewInit, Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import TemplateService from 'src/app/shared/services/template.service';

@Component({
    selector: 'app-loader',
    templateUrl: './loader.component.html',
    styleUrls: ['./loader.component.css']
})
export default class LoaderComponent implements OnInit, AfterViewInit, OnDestroy {
    @Output() private loaded = new EventEmitter<void>();
    @Output() private loadedingStarted = new EventEmitter<void>();

    private loadedSubscription: Subscription;
    private startedSubscription: Subscription;

    public loading: boolean;

    public constructor(
        private templateService: TemplateService
    ) { }

    public ngOnInit(): void {
        this.loadedSubscription = this.templateService.loaded.subscribe(() => this.fadeOut());
        this.startedSubscription = this.templateService.started.subscribe(() => this.fadeIn());
    }

    public ngAfterViewInit(): void {
        this.fadeIn();
    }

    public ngOnDestroy(): void {
        this.loadedSubscription.unsubscribe();
        this.startedSubscription.unsubscribe();
    }

    public fadeIn(): void {
        this.loading = true;

        this.loadedingStarted.emit();
    }

    public async fadeOut(): Promise<void> {
        this.loaded.emit();

        await new Promise(resolve => setTimeout(resolve, 500));

        this.loading = false;
    }
}
