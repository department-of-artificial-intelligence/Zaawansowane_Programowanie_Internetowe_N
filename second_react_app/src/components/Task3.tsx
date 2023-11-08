import { useState } from "react";



function Task3(){
    
    const [name, setName] = useState("");
    
    return <div><p>{name}</p><button onClick={() => setName("CHYR")}>klik</button></div>;
}
export default Task3;