import { useState } from "react";
import "./CompZad8.css";
const images = [
  "https://picsum.photos/200/300?random=1",
  "https://picsum.photos/200/300?random=2",
  "https://picsum.photos/200/300?random=3",
  "https://picsum.photos/200/300?random=4",
  "https://picsum.photos/200/300?random=5",
];

function CompZad8() {
  const [currentIndex, setCurrentIndex] = useState(0);

  const handleNextClick = () => {
    if (currentIndex < images.length - 1) {
      setCurrentIndex(currentIndex + 1);
    } else {
      alert("To ostatnie zdjęcie");
    }
  };
  const handlePrevClick = () => {
    if (currentIndex > 0) {
      setCurrentIndex(currentIndex - 1);
    } else {
      alert(
        "To pierwsze zdjęcie"
      );
    }
  };
  return (
    <div>
      <img src={images[currentIndex]} alt={""} />
      <button onClick={handlePrevClick}>Poprz.</button>
      <button onClick={handleNextClick}>Nast.</button>
    </div>
  );
};

export default CompZad8;
