import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { routes } from "./app.routes";
import { SharedModule } from "./shared/shared.module";

@NgModule({
    bootstrap: [AppComponent],
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        RouterModule.forRoot(routes),
        SharedModule
    ]
})
export class AppModule { }
