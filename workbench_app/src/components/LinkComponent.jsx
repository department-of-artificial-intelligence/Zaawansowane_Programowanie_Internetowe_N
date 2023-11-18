import React, { useState } from "react";
import "./LinkComponent.css"





export const LinkComponent = () => {
    
    const [links, setLinks] = useState([
        {id: 1, url: "https://hbogo.pl/", name: "HBO", isSelected: false},
        {id:2, url: "http://netflix.pl/", name: "Netflix", isSelected:false}
    ]);
    
    const toggleSelectionMultiple = (id) => {
        setLinks(links.map(link =>
            link.id == id ? {...link, isSelected: !link.isSelected}: link)
        );
    }

    //task 5
    const toggleSelectionSingle = (id) => {
        setLinks(links.map(link => 
          ({ ...link, isSelected: link.id === id })
        ));
    }

  return (
    <div className="App">
      <h1>My Favorite Links</h1>
      <ul>
        {links.map(link => (
          <li 
            key={link.id} 
            onClick={() => toggleSelectionMultiple(link.id)}
            style={{ 
              backgroundColor: link.isSelected ? 'lightblue' : 'transparent',
              cursor: 'pointer'
            }}>
            <a href={link.url} target="_blank" rel="noopener noreferrer">
              {link.name}
            </a>
          </li>
        ))}
      </ul>
    </div>
  );
}
