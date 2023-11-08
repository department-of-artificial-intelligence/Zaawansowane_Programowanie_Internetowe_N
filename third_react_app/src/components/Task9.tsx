import { useState } from "react";
import Task9a from "./Task9a";
import ReactDOM from "react-dom";

function Task9(){


    const [ flag, setFlag] = useState(false);



    return (
        <div>
        <button
        onClick={() => setFlag(true)}
        >klik</button>        
        { flag?<Task9a></Task9a>:<div></div> }
        </div>
        
    );
    
}

export default Task9;