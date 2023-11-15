import React, { useState } from 'react';
import { SelfIntroItem } from './SelfIntroItem';

export const SelfIntroState = () => {
    const [showName, setShowName] = useState(false);
    const selfIntroData = {
        firstName: 'Mateusz',
        lastName: 'Hanulok',
    };

    const handleClick = () => {
        setShowName(true);
    };

    return (
        <div>
            <p>
                {showName && <SelfIntroItem {...selfIntroData} />}
            </p>
            <button onClick={handleClick}>Show Name</button>
        </div>
    );
};