import { AfterViewInit, Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import TemplateService from 'src/app/shared/services/template.service';

@Component({
    selector: 'app-loading',
    templateUrl: './loading.component.html',
    styleUrls: ['./loading.component.css']
})
export default class LoadingComponent implements AfterViewInit {
    public redirectUrl: string;

    public constructor(
        private templateService: TemplateService,
        private route: ActivatedRoute
    ) { }

    public async ngAfterViewInit(): Promise<void> {
        this.route.queryParams.subscribe(params => this.redirectUrl = params.redirectUrl);

        this.templateService.TurnLoaderOff();
    }
}
