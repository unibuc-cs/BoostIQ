import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { AboutUsPageComponent } from './about-us-page/about-us-page.component';
import { HomeComponent } from './home-page/home.component';
import { LeaderboardPageComponent } from './leaderboard-page/leaderboard-page.component';
import { LearnPageComponent } from './learn-page/learn-page.component';
import { PlayPageComponent } from './play-page/play-page.component';
import { RegisterLoginComponent } from './register-login/register-login.component';

const routes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'learn', component: LearnPageComponent},
    { path: 'play', component: PlayPageComponent},
    { path: 'leaderboard', component: LeaderboardPageComponent},
    { path: 'about-us', component: AboutUsPageComponent},
    { path: 'login-register', component: RegisterLoginComponent},
    { path: '*', component: HomeComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}

export const routingComponents = [HomeComponent, LearnPageComponent, PlayPageComponent, 
    LeaderboardPageComponent, AboutUsPageComponent]
