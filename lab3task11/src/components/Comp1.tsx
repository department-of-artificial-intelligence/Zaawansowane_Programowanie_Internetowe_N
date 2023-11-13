import { useState } from "react";
import Comp2 from "./Comp2";


function Comp1(){
    const [ msg, setMsg] = useState("");
    const [ flag, setFlag] = useState(false);

    return(
        <div className="ComponentOne">
            <p>{msg}</p>
            <button
            onClick={() => setFlag(true)}
            >klik</button>
            
            { flag?<Comp2 flagSetter={setFlag} msgSetter={setMsg}></Comp2>:<div className='placeholder'></div> }
        </div>
    );
}

export default Comp1;