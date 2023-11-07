import React from 'react';
import './App.css';
import { ProductListItem } from './components/ProductListItem';
const App = () => {
    return (
        <div className="App">
            <ProductListItem id={1} name={"PC"} type={"Computers"} price={4000}></ProductListItem>
            <ProductListItem id={2} name={"PeeeC"} type={"Computers"} price={4000}></ProductListItem>
            <ProductListItem id={3} name={"PC"} type={"asd"} price={4000}></ProductListItem>

        </div>
    );
}
export default App;