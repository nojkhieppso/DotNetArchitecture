import { Component, ElementRef, Input } from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from "@angular/forms";
import { OptionModel } from "./option.model";

@Component({
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppSelectComponent, multi: true }],
    selector: "app-select",
    templateUrl: "./select.component.html"
})
export class AppSelectComponent implements ControlValueAccessor {
    @Input() options: OptionModel[];
    @Input() required: any;
    @Input() value: any;

    isDisabled: boolean;

    onTouched: any;

    constructor(private readonly el: ElementRef) {
        this.required = this.el.nativeElement.attributes.required;
    }

    onChange(value: any) { this.writeValue(value); }

    registerOnChange(fn: any): void { this.onChange = fn; }

    registerOnTouched(fn: any): void { this.onTouched = fn; }

    setDisabledState(isDisabled: boolean): void { this.isDisabled = isDisabled; }

    writeValue(obj: any): void { this.value = obj; }
}
