import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';

import Login from './pages/Login';
import Morador from './pages/Morador';
import NewMorador from './pages/NewMorador';
import Apartamento from './pages/Apartamento';

export default function Routes() {
    return (
        <BrowserRouter>
            <Route path="/" exact component={Login} />
            <Route path="/Morador" exact component={Morador} />
            <Route path="/Morador/New" exact component={NewMorador} />
            <Route path="/Apartamento" exact component={Apartamento} />
        </BrowserRouter>
    );
}