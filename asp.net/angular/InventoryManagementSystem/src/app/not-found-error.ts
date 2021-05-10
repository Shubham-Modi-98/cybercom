import { ErrorHandler } from "@angular/core"
import { LoaderService } from "./loader/loader.service";

export class NotFoundError implements ErrorHandler
{

    private spinnerServices!:LoaderService;
    constructor() { }

    handleError(error: any): void {
        this.spinnerServices.resetSpinner();
        alert('Unexpected Error Occured');
        console.log(error);
    }

}