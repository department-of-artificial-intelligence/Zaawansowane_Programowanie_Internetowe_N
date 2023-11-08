import { useState } from "react";

interface Props {
    id: number;
    fav: string;
}

function Task4a(props: Props){

    const [state, setState] = useState(0);


    return (
            <li
            key={props.id}
            className={state%2===0 ? "red" : "notred"}
            onClick={() => setState(state+1) }
            >{props.fav}</li>
    );
}
export default Task4a;