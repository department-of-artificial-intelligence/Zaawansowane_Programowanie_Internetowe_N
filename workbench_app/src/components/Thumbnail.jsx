import React from "react";

export const ThumbnailComponent = ({src,isSelected, onClick}) => {
    const style = isSelected ? {border: "2px solid red"} : {};
    return(
        <img src={src} alt="miniatura" style={{width: "50%", ...style}} onClick={onClick} />
    )
}