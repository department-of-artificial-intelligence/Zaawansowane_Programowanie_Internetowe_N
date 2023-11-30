import React from "react";
import "./App.css";
import { ProductListItem } from "./components/ProductListItem";
function App() {
  return (
    <div className="App">
      <ProductListItem
        id={1}
        name={"PC"}
        type={"Computers"}
        price={4000}
      ></ProductListItem>
    </div>
  );
}
export default App;
