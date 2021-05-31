import React from 'react';
import { Link } from 'react-router-dom';
import { FiPower, FiEdit, FiTrash2 } from 'react-icons/fi';

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

            <h1>Registre Moradores</h1>
            <ul>
                <li>
                    <strong>Nome:</strong>
                    <p>Felipe</p>
                    <strong>Sobrenome:</strong>
                    <p>Souza</p>
                    <strong>Nascimento:</strong>
                    <p>04/05/1995</p>
                    <strong>Telefone:</strong>
                    <p>9999999</p>
                    <strong>cpf:</strong>
                    <p>0000000000</p>
                    <strong>email:</strong>
                    <p>fm.cab@live.com</p>

                    <button type="button">
                        <FiEdit size={20} color="#742119" />
                    </button>

                    <button type="button">
                        <FiTrash2 size={20} color="#742119" />
                    </button>
                </li>

                <li>
                    <strong>Nome:</strong>
                    <p>Felipe</p>
                    <strong>Sobrenome:</strong>
                    <p>Souza</p>
                    <strong>Nascimento:</strong>
                    <p>04/05/1995</p>
                    <strong>Telefone:</strong>
                    <p>9999999</p>
                    <strong>cpf:</strong>
                    <p>0000000000</p>
                    <strong>email:</strong>
                    <p>fm.cab@live.com</p>

                    <button type="button">
                        <FiEdit size={20} color="#742119" />
                    </button>

                    <button type="button">
                        <FiTrash2 size={20} color="#742119" />
                    </button>
                </li>

                <li>
                    <strong>Nome:</strong>
                    <p>Felipe</p>
                    <strong>Sobrenome:</strong>
                    <p>Souza</p>
                    <strong>Nascimento:</strong>
                    <p>04/05/1995</p>
                    <strong>Telefone:</strong>
                    <p>9999999</p>
                    <strong>cpf:</strong>
                    <p>0000000000</p>
                    <strong>email:</strong>
                    <p>fm.cab@live.com</p>

                    <button type="button">
                        <FiEdit size={20} color="#742119" />
                    </button>

                    <button type="button">
                        <FiTrash2 size={20} color="#742119" />
                    </button>
                </li>

                <li>
                    <strong>Nome:</strong>
                    <p>Felipe</p>
                    <strong>Sobrenome:</strong>
                    <p>Souza</p>
                    <strong>Nascimento:</strong>
                    <p>04/05/1995</p>
                    <strong>Telefone:</strong>
                    <p>9999999</p>
                    <strong>cpf:</strong>
                    <p>0000000000</p>
                    <strong>email:</strong>
                    <p>fm.cab@live.com</p>

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