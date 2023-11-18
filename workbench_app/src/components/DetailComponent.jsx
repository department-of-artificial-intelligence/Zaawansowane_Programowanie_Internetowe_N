import React, { useState } from "react";
import "./DetailComponent.css";

export const DetailComponent = () => {
const [data, setData] = useState("");
    return(

        <div className="data">
            <p className="data-paragraph">Witaj, {data}!</p>
            <button type="button" onClick={() => setData("Błażej Dygas")}>Show</button>
        </div>
        

    );
}