import Reacto, { useState } from "react";
import "./CalculatorComponent.css";


export const CalculatorComponent = () => {
    const [counter, setCounter] = useState(0);

    const handleIncrement = () => {
        setCounter(counter + 1);
    }
    const handleDecrement = () => {
        setCounter(counter - 1);
    }
    const handleChange = (value) => {
        setCounter(counter + value)
    }

    return(
        <div class="calculator-container">
            <p>Value = {counter}</p>
            <button type="button" onClick={() => setCounter(counter + 1)}>+1</button>
            <button type="button" onClick={() => setCounter(counter - 1)}>-1</button>
            <button type="button" onClick={() => setCounter(counter + 2)}>+2</button>
            <button type="button" onClick={() => setCounter(counter - 2)}>-2</button>
        </div>
        
    );
}