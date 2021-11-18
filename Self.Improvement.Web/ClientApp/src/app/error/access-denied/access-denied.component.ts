import { AfterViewInit, Component } from '@angular/core';
import TemplateService from 'src/app/shared/services/template.service';

@Component({
    selector: 'app-access-denied',
    templateUrl: './access-denied.component.html',
    styleUrls: ['./access-denied.component.css']
})
export default class AccessDeniedComponent implements AfterViewInit {
    public constructor(
        private templateService: TemplateService
    ) { }

    public ngAfterViewInit(): void {
        this.templateService.TurnLoaderOff();
    }
}
