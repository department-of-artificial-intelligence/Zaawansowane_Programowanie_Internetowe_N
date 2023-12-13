import { IAddress } from "../models/IAddress";
export default interface IAddressService {
getAddresses(): Promise<IAddress[]>;
getAddress(id:number): Promise<IAddress>;
addOrUpdateAddress(addOrUpdateAddress: IAddress): Promise<IAddress>
deleteAddress(id:number): Promise<void>
}