import { User } from "../../../core/auth/model/user.model"
import { Company } from "./company.model"
import { Equipment } from "./equipment.model"

export interface Appointment {
    id: number,
    startTime: Date,
    duration: number,
    companyId: number,
    company: Company,
    adminId: number,
    admin?: User,
    buyerId?: number,
    buyer?: User,
    equipmentIds?: number[],
    equipment: Equipment[] 
}