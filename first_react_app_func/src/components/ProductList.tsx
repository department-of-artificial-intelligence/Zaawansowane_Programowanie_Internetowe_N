import { useState } from 'react';
import { IProductListState } from "../models/IProductListState";
import './ProductListItemF.css'
import IProduct from "../models/IProduct";
import { ProductListItem } from "./ProductListItem";
import { AddProductToList } from "../components/AddProductToList";
export const ProductList = ({ products }: { products: IProduct[] }): JSX.Element => {
    const [state, setState] = useState<IProductListState>({
        products: products != null ? products : [],
        name: ""
    });
    const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        let newState = { ...state }
        newState.name = e.target.value;
        setState(newState);
    }
    const onAddNewProductSubmit = (product: IProduct) => {
        let newState = { ...state }
        newState.products.push(product);
        setState(newState);
    }
    return (
        <div className="product-list">
            <div className="product-list-name-change-container">
                <input type="text" onChange={onInputChange} placeholder="product list name"></input>
            </div>
            <div className="product-list-name-container">
                <span className="product-list-name-text">
                    {state.name}
                </span>
            </div>
            <div className="list-container">
                {
                    state.name !== "" &&
                    state.products.map(product =>
                        <ProductListItem id={product.id}
                            key={product.id}
                            name={product.name}
                            type={product.type}
                            price={product.price}></ProductListItem>
                    )
                }
            </div>
            <AddProductToList submit={onAddNewProductSubmit}></AddProductToList>
        </div>
    );
}