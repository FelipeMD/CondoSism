import React from 'react';
import { Link } from 'react-router-dom';
import { FiPower, FiEdit, FiTrash2 } from 'react-icons/fi';

import './styles.css';

import logoImage from '../../assets/condosims-logo.svg'

export default function Apartamento() {
    return (
        <div className="apartamento-container">
            <header>
                <img src={logoImage} alt="logo" />
                <span>Bem Vindo, <strong>Usuario</strong></span>
                <Link className="button" to="apartamento/new">Adicionar Novo apartamento</Link>
                <button type="button">
                    <FiPower size="18" /> 
                </button>
            </header>

            <h1>Registre Moradores</h1>
            <ul>
                <li>
                    <strong>Número:</strong>
                    <p>1</p>
                    <strong>Bloco:</strong>
                    <p>b2</p>

                    <button type="button">
                        <FiEdit size={20} color="#742119" />
                    </button>

                    <button type="button">
                        <FiTrash2 size={20} color="#742119" />
                    </button>
                </li>
            </ul>
        </div>
    );
}