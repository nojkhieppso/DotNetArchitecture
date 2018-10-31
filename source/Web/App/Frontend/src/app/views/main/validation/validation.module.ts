import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../../../shared/shared.module";
import { ValidationComponent } from "./validation.component";

const routes: Routes = [
    { path: "", component: ValidationComponent }
];

@NgModule({
    declarations: [ValidationComponent],
    imports: [RouterModule.forChild(routes), SharedModule]
})
export class ValidationModule { }
