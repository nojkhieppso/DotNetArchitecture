import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { FooterComponent } from "./footer/footer.component";
import { HeaderComponent } from "./header/header.component";
import { LayoutMainComponent } from "./layout-main.component";
import { LayoutComponent } from "./layout.component";
import { MainComponent } from "./main/main.component";
import { NavComponent } from "./nav/nav.component";

@NgModule({
    declarations: [
        FooterComponent,
        HeaderComponent,
        LayoutComponent,
        LayoutMainComponent,
        MainComponent,
        NavComponent
    ],
    imports: [RouterModule]
})
export class LayoutModule { }
