import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { appendFile } from 'fs';
import { MyFavouritesComponent } from './my-favourites/my-favourites.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  {path:'CircleOfFifths/MyFavourites', component:MyFavouritesComponent},
  {path:':jwt', component:AppComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
