import React from 'react';
import { Link } from 'react-router-dom';
import { FiPower } from 'react-icons/fi';

import './styles.css';

import logoImage from '../../assets/condosims-logo.svg'

export default function Morador() {
    return (
        <div className="morador-container">
            <header>
                <img src={logoImage} alt="logo" />
                <span>Bem Vindo, <strong>Usuario</strong></span>
                <Link className="button" to="morador/new">Adicionar Novo Morador</Link>
                <button type="button">
                    <FiPower size="18" /> 
                </button>
            </header>
        </div>
    );
}