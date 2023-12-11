import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { ICategory } from "../../models/ICategory"
import { useContext, useEffect } from "react";
import CategoryContext from "../../contexts/CategoryContext";

type IState = {
    categories: ICategory[];
}

export const CategoryGrid = () =>{


    const columns: GridColDef[] =[
        {field: "id", headerName: "ID", width: 20},
        {field: "name", headerName: "Name", width: 200},
        {field: "tag", headerName: "Tag", width: 100},
        
    ]

    const {getCategories, state}:any = useContext(CategoryContext);

    useEffect(
        () => {
            getCategories();
        },[]
    );

    return (
        <div className="address-grid">
            <DataGrid
                rows={state.categories}
                columns={columns}            
            />
        </div>

    )
}