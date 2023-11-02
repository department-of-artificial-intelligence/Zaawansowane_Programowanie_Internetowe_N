import React from 'react';
import logo from './logo.svg';
import './App.css';
import { ProductListItem } from './components/ProductListItem';
import { ProductList } from './components/ProductList';
import IProduct from './models/IProduct';


function App() {
  const staticProducts: Array<IProduct> = [
    {
    id: 1,
    name :"DELL",
    type : "Computers",
    price: 4000
    },
    {
    id: 2,
    name :"Logitech 2000",
    type : "Mouses",
    price: 30
    },
    ]
    
  return (
    <div className="App">
      <ProductListItem id={1} name={"PC"} type={"Computers"} price={4000}></ProductListItem>
      <br></br>
      <ProductList products={staticProducts}></ProductList>
</div>
  );
}

export default App;
