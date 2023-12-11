import { ICategory } from "../../models/ICategory";

interface Props {
    category: ICategory;
}

export const CategoryListItem = ({category}: Props) =>{
    console.log("categorylist item constructed");

    return (        
        <div>
            <p>{category.id}</p>
            <p>{category.name}</p>
            <p>{category.tag}</p>
        </div>
    
    )
}