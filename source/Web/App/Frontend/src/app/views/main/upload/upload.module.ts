import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../../../shared/shared.module";
import { UploadComponent } from "./upload.component";

const routes: Routes = [
    { path: "", component: UploadComponent }
];

@NgModule({
    declarations: [UploadComponent],
    imports: [RouterModule.forChild(routes), SharedModule]
})
export class UploadModule { }
