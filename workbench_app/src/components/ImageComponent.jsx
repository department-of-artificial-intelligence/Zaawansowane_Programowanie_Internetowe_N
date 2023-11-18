import React, { useState } from "react";
import "./ImageComponent.css";
import img1 from "../images/img1.jpg"
import img2 from "../images/img2.jpg"


export const ImageComponent = () => {
    const images = [
        { id: 1, src: img1, title: "Image 1" },
        { id: 2, src: img2, title: "Image 2" },
        
    ];

    const [currentImageIndex, setCurrentImageIndex] = useState(0);
    const [message, setMessage] = useState('');

    const showNextImage = () => {
        if (currentImageIndex < images.length - 1) {
            setCurrentImageIndex(currentImageIndex + 1);
            setMessage('');
        } else {
            setMessage('To jest ostatnie zdjęcie w galerii.');
        }
    }

    const showPreviousImage = () => {
        if (currentImageIndex > 0) {
            setCurrentImageIndex(currentImageIndex - 1);
            setMessage('');
        } else {
            setMessage('To jest pierwsze zdjęcie w galerii.');
        }
    }

    return (
        <div className="App">
            <div className="image-container">
                <img src={images[currentImageIndex].src} alt={images[currentImageIndex].title} />
                <p>{message}</p>
            </div>
            <button onClick={showPreviousImage}>Poprzednie</button>
            <button onClick={showNextImage}>Następne</button>
        </div>
    );
}
