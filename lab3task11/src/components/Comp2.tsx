import { useState } from "react";

interface Props {
    flagSetter: Function;
    msgSetter: Function;
}

function Comp2(props:Props){
    

    function handleyes(){
        props.msgSetter("Cieszę się! Idźmy dalej!" );
        props.flagSetter(false);
    }
    
    function handleno(){
        props.msgSetter("Przykro mi, że się męczysz!" );
        props.flagSetter(false);
    }

    return(
        <div className="ComponentTwo">
           <p>Czy chesz dalej uczyć się biblioteki React?</p>     
           <button onClick={handleno}>nie</button>
           <button onClick={handleyes}>tak</button>       

        </div>
    );
}

export default Comp2;