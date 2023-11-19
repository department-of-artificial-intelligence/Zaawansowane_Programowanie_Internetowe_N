import React, { useState } from "react";
import { NotificationComponent } from "./NotificationComponent";

export const MainComponent = () => {
    const [showNotification, setShowNotification] = useState(false);

    const handleButtonClick = () => {
        setShowNotification(true);
    };

    const handleHideNotification = () => {
        setShowNotification(false);
    }

    return (
        <div className="main-container">
            {showNotification && <NotificationComponent onHideNotification={handleHideNotification} />}
            <button type="button" onClick={handleButtonClick}>Show notification</button>
        </div>
    );
}