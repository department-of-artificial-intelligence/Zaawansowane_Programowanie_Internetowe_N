import { useContext, useEffect } from "react";
import { ICategory } from "../../models/ICategory"
import CategoryContext from "../../contexts/CategoryContext";
import axios from "axios";
import { CategoryListItem } from "./CategoryListItem";

type IState = {
    categories: ICategory[];
}

export const CategoryList = () =>{
    console.log("categorylist constructed");
    const {getCategories, state}: any = useContext(CategoryContext);

    useEffect(() => {
        getCategories();
    }, []);

    console.log(state.categories);    
    return (        
        <div>
            {
            state.categories.map(
                (ct:ICategory) => <CategoryListItem category={ct}></CategoryListItem>
            )
        }
        </div>
    )
}