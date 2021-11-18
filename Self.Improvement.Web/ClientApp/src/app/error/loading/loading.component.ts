import { AfterViewInit, Component } from '@angular/core';
import TemplateService from 'src/app/shared/services/template.service';

@Component({
    selector: 'app-loading',
    templateUrl: './loading.component.html',
    styleUrls: ['./loading.component.css']
})
export default class LoadingComponent implements AfterViewInit {
    public constructor(
        private templateService: TemplateService
    ) { }

    public ngAfterViewInit(): void {
        this.templateService.TurnLoaderOff();
    }
}
