import { useState } from 'react';

function CompZad3() {
  const [name, setName] = useState('');

  const showName = () => {
    setName('Krzysztof Habko');
  };
  
  return (
    <div>
      <p>{name || "Imie"}</p>
      <button onClick={showName}>Przycisk</button>
    </div>
  );
}

export default CompZad3;
