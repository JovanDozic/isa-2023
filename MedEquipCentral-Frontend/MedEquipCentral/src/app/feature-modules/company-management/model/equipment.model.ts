import { Company } from "./company.model";
import { EquipmentType } from "./equipment-type.model";

export interface Equipment{
    id?: number,
    name: string,
    description?: string,
    typeId: number,
    type: EquipmentType,
    companyIds: number[],
    companies: Company[],
}