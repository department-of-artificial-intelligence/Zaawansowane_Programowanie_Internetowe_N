import React from "react";
import "./App.css";
import { ProductList } from "./components/ProductList";
import IProduct from "./models/IProduct";
import CompZad3 from './components/CompZad3';
import CompZad4 from './components/CompZad4';
import CompZad5 from './components/CompZad5';
import CompZad6 from './components/CompZad6';
import CompZad7 from './components/CompZad7';
import CompZad8 from './components/CompZad8';
import CompZad9 from './components/CompZad9';
import CompZad10 from './components/CompZad10';
const App = () => {
  const staticProducts: Array<IProduct> = [
    {
      id: 1,
      name: "DELL",
      type: "Computers",
      price: 4000,
    },
    {
      id: 2,
      name: "Logitech 2000",
      type: "Mouses",
      price: 30,
    },
  ];
  return (
    <div className="App">
      <ProductList products={staticProducts}></ProductList>
      <p>-----------------------------------</p>
      <CompZad3/>
      <p>Zad3</p>
      <p>-----------------------------------</p>
      <CompZad4/>
      <p>Zad4</p>
      <p>-----------------------------------</p>
      <CompZad5/>
      <p>Zad5</p>
      <p>-----------------------------------</p>
      <CompZad6/>
      <p>Zad6</p>
      <p>-----------------------------------</p>
      <CompZad7/>
      <p>Zad7</p>
      <p>-----------------------------------</p>
      <CompZad8/>
      <p>Zad8</p>
      <p>-----------------------------------</p>
      <CompZad9/>
      <p>Zad9</p>
      <p>-----------------------------------</p>
      <CompZad10/>
      <p>Zad10</p>
    </div>
  );
};
export default App;
