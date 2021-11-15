import { Component } from '@angular/core';

@Component({
    selector: 'app-counter-component',
    templateUrl: './counter.component.html'
})
export default class CounterComponent {
    public currentCount = 0;

    public incrementCounter(): void {
        this.currentCount++;
    }
}
