import { Routes } from "@angular/router";
import { AuthenticationGuard } from "./shared/guards/authentication.guard";
import { LayoutMainComponent } from "./shared/layout/layout-main.component";
import { LayoutComponent } from "./shared/layout/layout.component";
import { LoginComponent } from "./views/login/login.component";

export const routes: Routes = [
    {
        children: [
            { path: "", component: LoginComponent }
        ],
        component: LayoutComponent,
        path: ""
    },

    {
        canActivate: [AuthenticationGuard],
        children: [
            { path: "form", loadChildren: "./views/main/form/form.module#FormModule" },
            { path: "home", loadChildren: "./views/main/home/home.module#HomeModule" },
            { path: "service", loadChildren: "./views/main/service/service.module#ServiceModule" },
            { path: "upload", loadChildren: "./views/main/upload/upload.module#UploadModule" },
            { path: "validation", loadChildren: "./views/main/validation/validation.module#ValidationModule" }
        ],
        component: LayoutMainComponent,
        path: "main"
    },

    { path: "**", redirectTo: "" }
];
