import { User } from "../../../core/auth/model/user.model"
import { Company } from "./company.model"
import { Equipment } from "./equipment.model"

export interface Appointment {
    id: number,
    startTime: Date,
    duration: number,
    companyId: number,
    company: Company,
    adminName: string
    adminSurname: string
    adminId: number,
    buyerId?: number,
    buyer?: User,
    equipmentIds?: number[],
    equipment: Equipment[] 
}