import { useState } from "react";
import PhotoGalleryItem from "./PhotoGalleryItem";
import PhotoGalleryNavigation from "./PhotoGalleryNavigation";

export default function PhotoGallery(){
    const sc = "asdf";
    
    const dzban = "/obrazki/dzban.png"
    const kaczor = "/obrazki/kaczor.png"
    const pazdzioch = "/obrazki/pazdzioch.png"

    const obrazki = [dzban, kaczor, pazdzioch]
    //const [error, setError] = useState("");
    const [selectedIndex, setSelectedIndex] = useState(0);

    return (

        <div className="PhotoGallery">            
            <PhotoGalleryNavigation images={obrazki} imageSelector={setSelectedIndex}></PhotoGalleryNavigation>
            <div className="Photo">
                <PhotoGalleryItem id={selectedIndex} sc={obrazki[selectedIndex]} imageSelector={setSelectedIndex} size="notsmall"></PhotoGalleryItem>
            </div>
        </div>
    );
}