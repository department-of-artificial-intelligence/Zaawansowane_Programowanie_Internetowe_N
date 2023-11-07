import IProduct from '../models/IProduct';
import './ProductListItem.css'
export const ProductListItem = (product: IProduct): JSX.Element =>
    <div className="product-item">
        <div className="product-item-element">
            <label className="product-item-label">Id</label>
            <span className="product-item-span">{product.id}</span>
        </div>
        <div className="product-item-element">
            <label className="product-item-label">Name</label>
            <span className="product-item-span">{product.name}</span>
        </div>
        <div className="product-item-element">
            <label className="product-item-label">Price</label>
            <span className="product-item-span">{product.price}</span>
        </div>
        <div className="product-item-element">
            <label className="product-item-label">Type</label>
            <span className="product-item-span">{product.type}</span>
        </div>
    </div>