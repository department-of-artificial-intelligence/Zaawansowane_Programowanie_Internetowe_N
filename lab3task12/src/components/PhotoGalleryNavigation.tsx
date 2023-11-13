import PhotoGalleryItem from "./PhotoGalleryItem";

interface Props{
    images: Array<string>;
    imageSelector: Function;
}

export default function PhotoGalleryNavigation(props:Props){
    // return <PhotoGalleryItem sc={props.images[0]}></PhotoGalleryItem>
    return (
        <div className="PhotoGalleryNavigation">
            {props.images.map((sc, index) => <PhotoGalleryItem imageSelector={props.imageSelector} id={index} sc={sc} size="small" ></PhotoGalleryItem>)}
        </div>
    );
}

