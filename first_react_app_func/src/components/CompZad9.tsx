import { useState } from "react";
import "./CompZad9.css";
import Component9 from "./CompZad9NewComp";

function CompZad9(){
    const [showMessage, setShowMessage] = useState(false);

    const Click = () =>{
        setShowMessage(true);
    }

    return(
        <div>
            <button onClick={Click}>Przycisk</button>
            {showMessage && <Component9 />}
        </div>
    );
};
export default CompZad9;