import { User } from "../../../core/auth/model/user.model"

export interface Appointment {
    id: number,
    startTime: Date,
    duration: number,
    companyId: number,
    adminName: string
    adminSurname: string
    adminId: number,
    buyerId?: number,
    buyer?: User,
    equipmentIds?: number[],
}