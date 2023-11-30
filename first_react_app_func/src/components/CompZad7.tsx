import { useState } from 'react';
import './CompZad7.css';
function CompZad7() {
  const [count, setCount] = useState<number>(0);

  return(
    <div className="comp-zad7">
      <p>Liczba: {count}</p>
      <button onClick={() => setCount((prev) => prev - 2)}>-2</button>
      <button onClick={() => setCount((prev) => prev - 1)}>-1</button>
      <button onClick={() => setCount((prev) => prev + 1)}>+1</button>
      <button onClick={() => setCount((prev) => prev + 2)}>+2</button>
    </div>
  );
}
export default CompZad7;