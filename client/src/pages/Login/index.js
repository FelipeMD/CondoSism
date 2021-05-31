import React from 'react';

import './styles.css'

import logoImage from '../../assets/condosims-logo.svg'
//import padLock from '../../assets/padlock.png'


export default function Login() {
    return (
        <div className="logint-container">
            <section className="form">
                <img src={logoImage} alt="logo"/>
                <form>
                    <h1>Acesse sua conta</h1>
                    <input placeholder="Usuario" />
                    <input type="password" placeholder="Senha" />

                    <button className="button" type="submit">Login</button>
                </form>
            </section>
        </div>
    )
}