import { useState } from "react";
import Task9a from "./Task9a";
import ReactDOM from "react-dom";

function Task9(){

    const [ flag, setFlag] = useState(false);
    const [childData, setChildData] = useState("");


    return (
        <div>
        <button
        onClick={() => setFlag(true)}
        >klik</button>
        
        { flag?<Task9a passChildData={setFlag}></Task9a>:<div></div> }
        </div>
        
    );
    
}

export default Task9;