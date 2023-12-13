import React, { Component, useState } from 'react';
import { IAddress } from '../models/IAddress';
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import AddressService from '../services/AddressService';
import IAddressService from '../services/IAddressService';
const AddressContext = React.createContext({});
type IProps = { children: React.ReactNode };
type IState = { addresses: IAddress[] };
export const AddressProvider = (props: IProps) => {
const addressService: IAddressService = new AddressService();
const [state, setState] = useState<IState>();
const getAddresses = async (): Promise<IAddress[]> => {
const addresses = await addressService.getAddresses();
setState({ addresses: addresses });
return addresses;
}
const getAddress = async (id: number): Promise<IAddress> => {
const address = await addressService.getAddress(id)
return address;
}
const addOrUpdateAddress = async (address: IAddress) => {
await addressService.addOrUpdateAddress(address);
}
const deleteAddress = async (id:number): Promise<void> =>{
await addressService.deleteAddress(id);
}
return (
<AddressContext.Provider value={{
getAddresses,
getAddress,
addOrUpdateAddress,
deleteAddress
}}>
{props.children}
</AddressContext.Provider>
);
}
export default AddressContext;