import React from 'react';
import { Link } from 'react-router-dom';
import { FiArrowLeft } from 'react-icons/fi';

import './styles.css';

import logoImage from '../../assets/condosims-logo.svg'

export default function NewMorador(){
    return(
        <div className="new-morador-container">
            <div className="content">
                <section className="form">
                    <img src={logoImage} alt="logo" />
                    <h1>Adicionar Novo Morador</h1>
                    <p>Entre com as informações do novo morador e clique em 'Adicionar'</p>
                    <Link className="back-link" to="/morador">
                        <FiArrowLeft size={16} color="#742119" />
                        Home
                    </Link>
                </section>
                <form>
                    <input placeholder="Nome" />
                    <input placeholder="Sobrenome" />
                    <input type="date" />
                    <input placeholder="telefone" />
                    <input placeholder="cpf" />
                    <input placeholder="email" />

                    <button className="button" type="submit">Adicionar</button>
                </form>
            </div>
        </div>
    );
}