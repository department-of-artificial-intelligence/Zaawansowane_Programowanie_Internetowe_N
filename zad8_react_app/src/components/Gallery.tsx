import React, { useState, useEffect } from "react";
import fs from "fs";

const Gallery = () => {
  const [photo, setPhoto] = useState([]);
  const [actualPhoto, setActualPhoto] = useState(0);

  const readPhoto = async () => {
    const files = await fs.readdir("./photo");
    for (const afile of files) {
      if (afile.endsWith(".jpg")) {
        const img = await fs.readFile(`./photo/${afile}`, "base64");
        setPhoto((photo) => [...photo, { img, name: afile }]);
      }
    }
  };

  useEffect(() => {
    readPhoto();
  }, []);

  const nextPhoto = () => {
    if (actualPhoto < photo.length - 1) {
      setActualPhoto(actualPhoto + 1);
    } else {
      alert("Last photo");
    }
  };

  const prevPhoto = () => {
    if (actualPhoto > 0) {
        setActualPhoto(actualPhoto - 1);
    } else {
      alert("First photo");
    }
  };

  return (
    <div>
      <h1>Gallery</h1>
      <img src={photo[actualPhoto].image} alt={photo[actualPhoto].image} />
      <button onClick={nextPhoto}>Następne</button>
      <button onClick={prevPhoto}>Poprzednie</button>
    </div>
  );
};

export default Gallery;
