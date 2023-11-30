import { useState } from 'react';
import './CompZad5.css';
type LinkType = {
  name: string;
  url: string;
  color: string;
 };
const links: LinkType[] = [
  {name:'Embedded',url:'https://www.embedded.com/', color: 'blue' },
  {name:'Nature',url:'https://www.nature.com', color: 'blue' },
  {name:'Circuitcellar',url:'https://www.circuitcellar.com', color: 'blue' },
  {name:'YouTube',url:'https://www.youtube.com', color: 'blue' },
];
function CompZad5() {
  const [selectedLink, setSelectedLink] = useState<LinkType | null>(null);

  const handleClick = (link: LinkType) => {
    if (selectedLink === link) {
      setSelectedLink(null);
    } else {
      setSelectedLink(link);
    }
  };
  return (
    <div>
    <ul>
      {links.map((link) => (
        <li key={link.name}>
          <a href={link.url}
            onClick={(e) => {
              e.preventDefault();
              handleClick(link);
            }}
            style={{ color: selectedLink === link ? link.color : 'black' }}
          >
            {link.name}
          </a>
        </li>
      ))}
    </ul>
  </div>
  );
}

export default CompZad5;
