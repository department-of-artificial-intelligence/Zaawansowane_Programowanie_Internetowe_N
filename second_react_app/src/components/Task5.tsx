import { useState } from "react";



function Task5(){

    let favorites = ["http://4chan.org", "http://sadistic.pl", "http://joemonster.org"]
    
    const [selectedIndex, setSelectedIndex] = useState(-1);

    return (
        <ul>
            {
            favorites.map((fav, index) => <li 
            key={fav} 
            className={ selectedIndex === index ? "red" : "notred"}
             onClick={() => setSelectedIndex(index)}>{fav}</li>)}

        </ul>

    );
}
export default Task5;