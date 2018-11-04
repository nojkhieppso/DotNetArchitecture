import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../../../shared/shared.module";
import { FormComponent } from "./form.component";

const routes: Routes = [
    { path: "", component: FormComponent }
];

@NgModule({
    declarations: [FormComponent],
    imports: [RouterModule.forChild(routes), SharedModule]
})
export class FormModule { }
