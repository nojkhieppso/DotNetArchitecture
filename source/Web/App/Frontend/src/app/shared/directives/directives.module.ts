import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ValidationModule } from "./validation/validation.module";

@NgModule({
    exports: [
        ValidationModule
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ValidationModule
    ]
})
export class DirectivesModule { }
