import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { CustomHttpInterceptor } from "./http.interceptor";

@NgModule({
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: CustomHttpInterceptor, multi: true }
    ]
})
export class InterceptorsModule { }
