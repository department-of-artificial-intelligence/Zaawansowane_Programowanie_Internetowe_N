import React, { useState } from "react";

const Counter = () => {
  const [number, setNumber] = useState(0);

  const addOne = () => setNumber(number + 1);
  const substractOne = () => setNumber(number - 1);

  return (
    <div>
      <p>Liczba: {number}</p>
      <button onClick={addOne}>+1</button>
      <button onClick={substractOne}>-1</button>
    </div>
  );
};

export default Counter;
