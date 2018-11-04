import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CurrencyDirective } from "./currency.directive";
import { DateDirective } from "./date.directive";
import { DecimalDirective } from "./decimal.directive";
import { IntegerDirective } from "./integer.directive";

@NgModule({
    declarations: [
        CurrencyDirective,
        DateDirective,
        DecimalDirective,
        IntegerDirective
    ],
    exports: [
        CurrencyDirective,
        DateDirective,
        DecimalDirective,
        IntegerDirective
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class ValidationModule { }
