import { useState } from 'react';
import './CompZad6.css';
function CompZad6() {
  const [count, setCount] = useState<number>(0);

  return(
    <div className="comp-zad6">
      <p>Liczba: {count}</p>
      <button onClick={() => setCount((prev) => prev + 1)}>+</button>
      <button onClick={() => setCount((prev) => prev - 1)}>-</button>
    </div>
  );
}
export default CompZad6;