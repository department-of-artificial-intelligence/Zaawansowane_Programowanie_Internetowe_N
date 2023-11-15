import React, { useState } from 'react';
import ILink from '../models/ILink';

const favoriteLinksData: ILink[] = [
    { id: 1, name: 'Google', url: 'https://www.google.com/' },
    { id: 2, name: 'GitHub', url: 'https://github.com/' },
    { id: 3, name: 'React', url: 'https://reactjs.org/' },
  ];
  
  const FavoriteLinksItem = () => {
    const [selectedLinks, setSelectedLinks] = useState<number[]>([]);
  
    const handleLinkClick = (id: number) => {
      const isSelected = selectedLinks.includes(id);
  
      if (isSelected) {
        // Remove the link from selectedLinks
        setSelectedLinks(selectedLinks.filter((linkId) => linkId !== id));
      } else {
        // Add the link to selectedLinks
        setSelectedLinks([...selectedLinks, id]);
      }
    };
  
    return (
      <div className="favorite-links-list">
        <h1>Favorite Links</h1>
        <ul>
          {favoriteLinksData.map((link) => (
            <li
              key={link.id}
              onClick={() => handleLinkClick(link.id)}
              style={{
                backgroundColor: selectedLinks.includes(link.id) ? '#4CAF50' : '',
                cursor: 'pointer',
              }}
            >
              <a href={link.url} target="_blank" rel="noopener noreferrer">
                {link.name}
              </a>
            </li>
          ))}
        </ul>
      </div>
    );
  };
  
  export default FavoriteLinksItem;