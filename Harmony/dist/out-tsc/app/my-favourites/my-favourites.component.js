import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { harmonyVM } from './harmony.model';
let MyFavouritesComponent = class MyFavouritesComponent {
    constructor(myFavouritesService, formBuilder) {
        this.myFavouritesService = myFavouritesService;
        this.formBuilder = formBuilder;
        this.myFavourites = [];
        this.itemImageUrl = '../assets/logoutButton.png';
    }
    ngOnInit() {
        this.filterForm = new FormGroup({
            key: new FormControl(''),
            numberOfChords: new FormControl(''),
            isMagic: new FormControl('')
        });
        this.getMyFavourites();
        this.filterForm.valueChanges.subscribe(values => {
            console.log(values);
            this.filterMyFavourites(values);
        });
        console.log(this.myFavourites);
    }
    getMyFavourites() {
        this.myFavouritesService.getAll().subscribe(myFavourites => {
            this.myFavourites = [];
            myFavourites.forEach(harmony => {
                this.myFavourites.push(new harmonyVM(harmony));
            });
        });
    }
    delete(id) {
        this.myFavouritesService.delete(id).subscribe(() => {
            this.getMyFavourites();
        });
    }
    filterMyFavourites(values) {
        this.myFavouritesService.filter(values).subscribe((response) => {
            this.myFavourites = [];
            if (response.body != null) {
                response.body.forEach(harmony => {
                    this.myFavourites.push(new harmonyVM(harmony));
                });
            }
        });
    }
};
MyFavouritesComponent = __decorate([
    Component({
        selector: 'app-my-favourites',
        templateUrl: './my-favourites.component.html',
        styleUrls: ['./my-favourites.component.css']
    })
], MyFavouritesComponent);
export { MyFavouritesComponent };
//# sourceMappingURL=my-favourites.component.js.map