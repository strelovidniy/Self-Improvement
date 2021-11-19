import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Goal from '../types/Goal';
import EndpointService from './endpoint.service';

@Injectable({
    providedIn: 'root'
})
export default class GoalService {

    public constructor(
        private endpointService: EndpointService,
        private http: HttpClient
    ) { }

    public getGoalsByUserId(userId: string): Promise<Goal[]> {
        return this.http.get<Goal[]>(`${this.endpointService.goalsUrl}by-user/${userId}`).toPromise();
    }

    public getActiveGoalsByUserId(userId: string): Promise<Goal[]> {
        return this.http.get<Goal[]>(`${this.endpointService.goalsUrl}active/${userId}`).toPromise();
    }

    public getGoalById(goalId: string): Promise<Goal> {
        return this.http.get<Goal>(`${this.endpointService.goalsUrl}${goalId}`).toPromise();
    }

    public addGoal(goal: Goal): Promise<Goal> {
        return this.http.post<Goal>(`${this.endpointService.goalsUrl}`, goal).toPromise();
    }
}
