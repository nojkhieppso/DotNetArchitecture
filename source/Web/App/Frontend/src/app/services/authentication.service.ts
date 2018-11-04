import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { SignInModel } from "../models/signIn.model";
import { TokenService } from "../shared/services/token.service";

@Injectable({ providedIn: "root" })
export class AuthenticationService {
    constructor(
        private readonly http: HttpClient,
        private readonly router: Router,
        private readonly tokenService: TokenService) { }

    signIn(signIn: SignInModel): void {
        this.http
            .post(`Authentication/SignIn`, signIn, { responseType: "text" })
            .subscribe((token: string) => {
                this.tokenService.set(token);
                this.router.navigate(["/main/home"]);
            });
    }

    signOut() {
        if (this.tokenService.any()) {
            this.http.post(`Authentication/SignOut`, {}).subscribe();
        }

        this.tokenService.clear();
        this.router.navigate(["/login"]);
    }
}
