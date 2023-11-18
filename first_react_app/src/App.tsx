import React from 'react';
import logo from './logo.svg';
import './App.css';
//import { ProductListItem } from './components/ProductListItem';
import IProduct from './models/IProduct';
import { ProductList } from './components/ProductList';

function App() {

      // <div className="App">
      //   <ProductListItem id={1} name={"PC"} type={"Computers"} price={4599.99}></ProductListItem>
      // </div>
      let staticProducts: Array<IProduct> =[
        {
          id: 1,
          name: "DELL",
          type: "Computers",
          price: 4000
        },
        {
          id:2,
          name: "Logitech 2000",
          type: "Mouses",
          price: 30
        }
      ]
      return(
        <div className="App">
          <ProductList products={staticProducts}></ProductList>
        </div>
      );
    
  // return (
  //   <div className="App">
  //     <header className="App-header">
  //       <img src={logo} className="App-logo" alt="logo" />
  //       <p>
  //         Edit <code>src/App.tsx</code> and save to reload.
  //       </p>
  //       <a
  //         className="App-link"
  //         href="https://reactjs.org"
  //         target="_blank"
  //         rel="noopener noreferrer"
  //       >
  //         Learn React
  //       </a>
  //     </header>
  //   </div>
  // );
}

export default App;
