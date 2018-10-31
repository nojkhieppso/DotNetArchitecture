import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../../../shared/shared.module";
import { ServiceComponent } from "./service.component";

const routes: Routes = [
    { path: "", component: ServiceComponent }
];

@NgModule({
    declarations: [ServiceComponent],
    imports: [RouterModule.forChild(routes), SharedModule]
})
export class ServiceModule { }
