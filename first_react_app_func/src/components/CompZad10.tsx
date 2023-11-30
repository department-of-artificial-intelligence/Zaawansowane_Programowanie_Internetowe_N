import { useState } from "react";
import "./CompZad10.css";
import Component10 from "./CompZad10NewComp";

function CompZad10(){
    const [showMessage, setShowMessage] = useState(false);

    const Click = () =>{
        setShowMessage(true);
    }

    return(
        <div>
            <button onClick={Click}>Przycisk</button>
            {showMessage && <Component10 hide={() => setShowMessage(false)}/>}
        </div>
    );
};
export default CompZad10;