import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { AppComponent } from "../../app.component";
import { UserProfileComponent } from "./user-profile/user-profile.component"
import { RouterModule } from "@angular/router";
import { SystemAdminsManagementComponent } from "./system-admins-management/system-admins-management.component";

@NgModule({
    declarations: [
        UserProfileComponent,
        SystemAdminsManagementComponent
    ],
    imports: [
      BrowserModule,
      ReactiveFormsModule,
      HttpClientModule,
      RouterModule,
      FormsModule
    ],
    exports:[
        UserProfileComponent,
        SystemAdminsManagementComponent
    ],
    providers: [],
    bootstrap: [AppComponent]
  })
  export class UserManagementModule { }