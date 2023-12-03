import React, { useState } from "react";
import axios from "axios";
import { IAddress } from "../models/IAddress";
const AddressContext = React.createContext({});
type IProps = { children: React.ReactNode };
type IState = {
  addresses: IAddress[];
};
export const AddressProvider = (props: IProps) => {
  const [state, setState] = useState<IState>({ addresses: [] });
  const getAddresses = async () => {
    const response = await axios.get<IAddress[]>("/api/Address");
    setState({ addresses: response.data });
  };
  return (
    <AddressContext.Provider
      value={{
        state,
        getAddresses,
      }}
    >
      {props.children}
    </AddressContext.Provider>
  );
};
export default AddressContext;
