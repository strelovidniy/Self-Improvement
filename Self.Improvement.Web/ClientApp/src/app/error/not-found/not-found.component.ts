import { AfterViewInit, Component } from '@angular/core';
import TemplateService from 'src/app/shared/services/template.service';

@Component({
    selector: 'app-not-found',
    templateUrl: './not-found.component.html',
    styleUrls: ['./not-found.component.css']
})
export default class NotFoundComponent implements AfterViewInit {
    public constructor(
        private templateService: TemplateService
    ) { }

    public ngAfterViewInit(): void {
        this.templateService.TurnLoaderOff();
    }
}
