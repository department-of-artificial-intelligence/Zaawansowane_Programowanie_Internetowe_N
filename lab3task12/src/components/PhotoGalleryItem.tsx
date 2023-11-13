interface Props{
    id: number;
    sc:string;
    size:string;
    imageSelector:Function;
}

 function PhotoGalleryItem(props:Props){
    function handle(){
        props.imageSelector(props.id);
    }

    if (props.size=="small"){
        return (
            <img id={props.id.toString()} src={props.sc} alt={props.sc} onClick={handle} className="smallimage"></img>
        );
    }
    else{
        return (
            <img src={props.sc} alt={props.sc}  className="bigimage"></img>
        );
    }
}

export default PhotoGalleryItem;