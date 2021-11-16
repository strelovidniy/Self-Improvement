import { AfterViewInit, Component } from '@angular/core';
import TemplateService from '../shared/services/template.service';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export default class DashboardComponent implements AfterViewInit {

    public constructor(
        private templateService: TemplateService
    ) { }

    public ngAfterViewInit(): void {
        this.templateService.TurnLoaderOff();
    }
}
