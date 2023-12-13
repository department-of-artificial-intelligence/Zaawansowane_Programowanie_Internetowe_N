import { IAddress } from '../models/IAddress'
import BaseService from './BaseService'
import IAddressService from './IAddressService';
export default class AddressService extends BaseService implements IAddressService {
async deleteAddress(id: number): Promise<void> {
await fetch(`${this._apiUrl}/api/Address/${id}`, { method: "DELETE" });
}
async addOrUpdateAddress(address: IAddress): Promise<IAddress> {
const response = await fetch(`${this._apiUrl}/api/Address`, {
method: "POST", // GET, POST, PUT, DELETE, etc.
headers: {
'Content-Type': 'application/json'
},
body: JSON.stringify(address)
});
address = await response.json();
return address;
}
async getAddress(id: number): Promise<IAddress> {
const response = await fetch(`${this._apiUrl}/api/Address/${id}`, { method: "GET" });
const address: IAddress = await response.json();
return address;
}
async getAddresses(): Promise<IAddress[]> {
const response = await fetch(`${this._apiUrl}/api/Address`, { method: "GET" });
const addreses: IAddress[] = await response.json();
return addreses;
}
}