import { UserRole } from "../../../core/auth/model/user.model";

export interface User{
    id: number;
    email: string;
    password?: string;
    confirmPassword?: string,
    name: string;
    surname: string;
    city?: string;
    country?: string;
    phone?: string;
    job?: string;
    companyId?: number,
    userRole?: UserRole
    companyInfo?: string;
}
