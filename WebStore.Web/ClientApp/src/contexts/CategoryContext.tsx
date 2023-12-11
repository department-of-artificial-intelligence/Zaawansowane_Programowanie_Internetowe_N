import axios from "axios";
import { ICategory } from "../models/ICategory";
import React, { useState } from 'react';

const CategoryContext = React.createContext({});
type IProps = {children: React.ReactNode};
type IState = {
    categories: ICategory[]
};

export const CategoryProvider = (props: IProps) => {
    const [state, setState] = useState<IState>({categories: []});
    const getCategories = async () =>{
        const rep = await axios.get<ICategory[]>("/api/Category");
        setState({categories: rep.data});
        console.log(rep.data);
    }
    return (
        <CategoryContext.Provider value={{
                state, 
                getCategories,
            }}>
            {props.children}
        </CategoryContext.Provider>
    );
}
export default CategoryContext;
