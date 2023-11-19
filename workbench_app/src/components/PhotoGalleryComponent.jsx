import React from "react";
import { useState } from "react";
import { ThumbnailComponent } from "./Thumbnail";
import img1 from "../images/img1.jpg"
import img2 from "../images/img2.jpg"

export const PhotoGalleryComponent = () => {

    const [selectedPhoto, setSelectedPhoto] = useState(null);
    const staticPhotos = 
    [
        {id: 1, src: img1, name: "img1", isSelected: false},
        {id:2, src: img2, name: "img2", isSelected:false}
    ];
    return(
        <div className="photogallery-container" style={{display: "flex"}}>
            <div style={{width: "50%"}}>
                {
                    staticPhotos.map(photo => 
                        <ThumbnailComponent key={photo.id} src={photo.src} isSelected={selectedPhoto === photo.id} onClick={() => setSelectedPhoto(photo.id)} />)
                }
            </div>
            <div style={{width: "50%"}}>
                {
                    selectedPhoto ? <img src={staticPhotos.find(p => p.id === selectedPhoto).src} style={{width: "50%"}}/> : {}
                }
            </div>
        </div>
    );
}