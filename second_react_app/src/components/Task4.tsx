import { useState } from "react";
import Task4a from "./Task4a";


function Task4(){

    let favorites = ["http://4chan.org", "http://sadistic.pl", "http://joemonster.org"]
    
    const [selectedIndex, setSelectedIndex] = useState(-1);

    return (
        <ul>
            {
            favorites.map((fav, index) => 
            <Task4a fav={fav} id={index}></Task4a>
            )}

        </ul>

    );
}
export default Task4;