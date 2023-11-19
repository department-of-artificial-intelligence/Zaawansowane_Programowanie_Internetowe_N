import React from "react";

export const UserNotificationComponent = ( {onSelectButton} ) => {
    return (
        <div className="notification-component">
            <p>Czy chcesz dalej uczyć się biblioteki React?</p>
            <button type="button" onClick={() => onSelectButton(true)}>Tak</button>
            <button type="button" onClick={() => onSelectButton(false)}>Nie</button>
        </div>
    );
};