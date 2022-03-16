import { __decorate } from "tslib";
import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
let MyFavouritesService = class MyFavouritesService {
    constructor(httpClient) {
        this.httpClient = httpClient;
    }
    getAll() {
        return this.httpClient.get("https://localhost:44383/api/MyFavoritesAPI");
    }
    delete(id) {
        return this.httpClient.delete(`https://localhost:44383/api/MyFavoritesAPI/${id}`);
    }
    filter(values) {
        const params = new HttpParams({ fromObject: values });
        return this.httpClient.get("https://localhost:44383/api/MyFavoritesAPI/filter", { params, observe: 'response' });
    }
};
MyFavouritesService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], MyFavouritesService);
export { MyFavouritesService };
//# sourceMappingURL=my-favourites.service.js.map