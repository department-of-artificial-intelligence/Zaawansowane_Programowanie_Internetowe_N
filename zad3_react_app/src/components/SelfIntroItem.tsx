import React from 'react';
import ISelfIntro from '../models/ISelfIntro';
import './SelfIntroItem.css';

export class SelfIntroItem extends React.Component<ISelfIntro> {
    render() {
        const { firstName, lastName} = this.props;

        return (
            <div className="intro-item">
                <div className="intro-item-element">
                    <label className="intro-item-label">First Name</label>
                    <span className="intro-item-span">{firstName}</span>
                </div>
                <div className="intro-item-element">
                    <label className="intro-item-label">Last Name</label>
                    <span className="intro-item-span">{lastName}</span>
                </div>
            </div>
        );
    }
}
