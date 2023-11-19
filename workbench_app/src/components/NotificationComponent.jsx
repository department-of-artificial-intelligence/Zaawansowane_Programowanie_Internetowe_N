import React from "react";

export const NotificationComponent = ({onHideNotification}) => {
    return (
        <div className="notification-container">
            <p>Simple notification</p>
            <button type="button" onClick={onHideNotification}>Hide notification</button>
        </div>
    );
};