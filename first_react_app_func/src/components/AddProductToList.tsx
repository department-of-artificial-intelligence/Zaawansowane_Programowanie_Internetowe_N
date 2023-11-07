import { useState } from 'react';
import IProduct from "../models/IProduct";
import './AddProductToList.css'
type ProductState = {
    id: number,
    name: string,
    type: string,
    price: number
}
export const AddProductToList = ({ submit }: { submit: (product: IProduct) => void }): JSX.Element => {
    const [state, setState] = useState<ProductState>({
        id: 0,
        name: "",
        type: "",
        price: 0.0
    });
    const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const name = e.target.name as keyof typeof state;
        setState((prevState => ({ ...prevState, [name]: e.target.value })));
    }
    const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        submit(state);
    }
    return (
        <div className="form-container">
            <form onSubmit={onSubmit}>
                <div className="product-item-element">
                    <input className="product-item-input"
                        name="id"
                        placeholder="id"
                        onChange={onInputChange}
                        value={state.id}
                    >
                    </input>
                </div>
                <div className="product-item-element">
                    <input className="product-item-input"
                        name="name"
                        placeholder="name"
                        onChange={onInputChange}
                        value={state.name}
                    >
                    </input>
                </div>
                <div className="product-item-element">
                    <input className="product-item-input"
                        name="type"
                        placeholder="type"
                        onChange={onInputChange}
                        value={state.type}
                    >
                    </input>
                </div>
                <div className="product-item-element">
                    <input className="product-item-input"
                        name="price"
                        placeholder="price"
                        onChange={onInputChange}
                        value={state.price}
                    >
                    </input>
                </div>
                <button type="submit">Add</button>
            </form>
        </div>
    );
}
