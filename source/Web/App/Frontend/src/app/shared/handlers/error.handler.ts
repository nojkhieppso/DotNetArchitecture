import { ErrorHandler, Injectable, Injector } from "@angular/core";
import { Router } from "@angular/router";
import { ModalService } from "../services/modal.service";

@Injectable()
export class CustomErrorHandler implements ErrorHandler {
    constructor(private readonly injector: Injector) { }

    handleError(error: any) {
        const modalService = this.injector.get(ModalService);
        const router = this.injector.get(Router);

        if (!error.status) { return; }

        switch (error.status) {
            case 422: {
                modalService.alert(error.error);
                break;
            }
            case 401: {
                router.navigate(["/login"]);
                break;
            }
            default: {
                console.log(error);
                break;
            }
        }
    }
}
