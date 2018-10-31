import { Directive, OnInit } from "@angular/core";
import { ValidationDirective } from "./validation.directive";

@Directive({ selector: "[appInteger]" })
export class IntegerDirective extends ValidationDirective implements OnInit {
    ngOnInit() {
        this.cleave = new this.Cleave(this.selector, {
            blocks: [20],
            numericOnly: true
        });
    }
}
