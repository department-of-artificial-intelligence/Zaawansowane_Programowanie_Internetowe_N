import { useState } from "react";

function Task67(){
    const [counter, setCounter] = useState(0);

    return (
        <div>
            <p>{counter}</p>
            <button onClick={()=>setCounter(counter-1)}>ujmij!</button>
            <button onClick={() => setCounter(counter+1)}>dorzuć!</button>
            <button onClick={()=>setCounter(counter-2)}>ujmij dwa!</button>
            <button onClick={() => setCounter(counter+2)}>dorzuć dwa!</button>
        </div>
    );
}
export default Task67;