import React, { createContext, useState } from 'react';
import axios from 'axios';
import { IAddress } from '../models/IAddress';

const AddressContext = createContext({});
type IProps = { children: React.ReactNode };
type IState = {
  addresses: IAddress[];
};

export const AddressProvider = (props: IProps) => {
  const [state, setState] = useState<IState>({ addresses: [] });

  const getAddresses = async () => {
    try {
      const response = await axios.get<IAddress[]>("/api/Address");
      setState({ addresses: response.data });
    } catch (error) {
      console.error('Error fetching addresses:', error);
    }
  };

  return (
    <AddressContext.Provider value={{
      state,
      getAddresses,
    }}>
      {props.children}
    </AddressContext.Provider>
  );
};

export default AddressContext;
