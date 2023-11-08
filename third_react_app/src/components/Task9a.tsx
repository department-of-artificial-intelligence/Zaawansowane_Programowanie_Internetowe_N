interface Props {
    passChildData: Function;
}

function Task9a(props:Props){

    function handle(){
        props.passChildData(false);
    }
        
    return <div>
        <p>dowolny komunikat</p>
        <button onClick={handle}>ukryj komunikat</button>
    </div>;
}

export default Task9a;