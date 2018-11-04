import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ComponentsModule } from "./components/components.module";
import { DirectivesModule } from "./directives/directives.module";
import { GuardsModule } from "./guards/guards.module";
import { HandlersModule } from "./handlers/handlers.module";
import { InterceptorsModule } from "./interceptors/interceptors.module";

@NgModule({
    exports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        ComponentsModule,
        DirectivesModule,
        GuardsModule,
        HandlersModule,
        InterceptorsModule
    ],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        ComponentsModule,
        DirectivesModule,
        GuardsModule,
        HandlersModule,
        InterceptorsModule
    ]
})
export class SharedModule { }
