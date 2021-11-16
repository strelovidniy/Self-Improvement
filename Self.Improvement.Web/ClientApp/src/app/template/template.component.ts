import { Component } from '@angular/core';

@Component({
    selector: 'app-template',
    templateUrl: './template.component.html',
    styleUrls: ['./template.component.css']
})
export default class TemplateComponent {
    public onLoaded(): void {
        document.getElementById('container').style.opacity = '1';
    }

    public onLoadingStarted(): void {
        document.getElementById('container').style.opacity = '0';
    }

    public referToTelegramBot(): void {
        location.href = 'https://t.me/yours_improvement_bot';
    }
}
