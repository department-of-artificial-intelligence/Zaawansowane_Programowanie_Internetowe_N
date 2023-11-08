import { useState } from "react";

function Task8(){

    const dzban = "/obrazki/dzban.png"
    const kaczor = "/obrazki/kaczor.png"
    const pazdzioch = "/obrazki/pazdzioch.png"

    const obrazki = [dzban, kaczor, pazdzioch]
    const [error, setError] = useState("");
    const [selectedIndex, setSelectedIndex] = useState(0);

    function back() {
        if(selectedIndex<=0){
            setError("Nie istnieje poprzednie względem pierwszego");
        }
        else{
            setSelectedIndex(a => a-1);
            setError("");
        }
      }

    function forward() {
        if(selectedIndex>=obrazki.length-1){
            setError("Następne względem ostatniego też nie istnieje");
        }
        else{
            setSelectedIndex(a => a+1);
            setError("");
        }
      }


    return (
        <div>
            <h1>{error}</h1>
           <div className="imagegallery">
            
            <button onClick={back}>poprzedni</button>
           <img src={obrazki[selectedIndex]} ></img>
           <button onClick={forward}>nastepny</button>
           
           </div>
        </div>
    );
}
export default Task8;