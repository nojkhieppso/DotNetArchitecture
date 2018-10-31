import { NgModule } from "@angular/core";
import { AuthenticationGuard } from "./authentication.guard";

@NgModule({
    providers: [AuthenticationGuard]
})
export class GuardsModule { }
