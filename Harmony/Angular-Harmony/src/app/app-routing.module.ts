import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MyFavouritesComponent } from './my-favourites/my-favourites.component';

const routes: Routes = [
  {path:'CircleOfFifths/MyFavourites', component:MyFavouritesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
