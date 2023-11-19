import React, { useState } from "react";
import { UserNotificationComponent } from "./UserNotificationComponent";

export const UserMainComponent = () => {
    const [showUserNotification, setShowUserNotification] = useState(false);
    const [userResponse, setUserResponse] = useState(null); 

    const handleButtonClick = () => {
        setShowUserNotification(true);
    };


    const handleUserResponse = (response) => {
        setUserResponse(response);
        setShowUserNotification(false);
    };

    return (
        <div className="main-container">
            
            {!showUserNotification && <button onClick={handleButtonClick}>Show notification</button>}
            {showUserNotification && <UserNotificationComponent onSelectButton={handleUserResponse} />}
            {userResponse !== null && <p>{userResponse ? "Cieszę się! Idźmy dalej!" : "Przykro mi, że się męczysz!"}</p>}
        </div>
    );
};