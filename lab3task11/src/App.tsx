import React, { useState } from 'react';
import './App.css';
import Comp1 from './components/Comp1';

function App() {

  

  return (
    <div className="App" id='ParentComponent'>
       <Comp1 ></Comp1>
    </div>
  );
}

export default App;
