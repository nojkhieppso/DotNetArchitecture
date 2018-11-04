import { ErrorHandler, NgModule } from "@angular/core";
import { CustomErrorHandler } from "./error.handler";

@NgModule({
    providers: [
        { provide: ErrorHandler, useClass: CustomErrorHandler }
    ]
})
export class HandlersModule { }
