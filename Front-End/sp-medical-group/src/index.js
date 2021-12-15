//importação de Dependencias
import React from 'react';
import ReactDOM from 'react-dom';
import reportWebVitals from './reportWebVitals';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';

// Importação de CSS
import './index.css';

// Importação das pages
// import App from './pages/Home/App.js';
import Login from './pages/Login/login.jsx';
import ConsultaMedico from './pages/ConsultasMedico/ConsultaMedico.jsx';
import ConsultaPaciente from './pages/ConsultasPaciente/ConsultasPaciente';
import TodasasConsultas from './pages/TodasasConsultas/TodasasConsultas';
import Cadastrar from './pages/CadastrarConsultas/Cadastrar';
import NotFound from './pages/notFound/notFound';
import AtualizarDescricao from './pages/AtualizarDescricao/Descricao.jsx';
import Localizacao from './pages/Localizacao/Localizacao';

const routing = (
  <Router>
    <div>
      <Switch>
        {/* <Route exact path="/" component={App} /> Home */}
        <Route exact path="/" component={Login} /> {/* Login */}
        <Route path="/consultasmedico" component={ConsultaMedico} /> {/* Consultas do Medico */}
        <Route path="/consultaspaciente" component={ConsultaPaciente} /> {/* Cosultas do Paciente */}
        <Route path="/todasasconsultas" component={TodasasConsultas} /> {/* Todas as Consultas */}
        <Route path="/cadastrar" component={Cadastrar} /> {/* Cadastrar Consulta */}
        <Route path="/atualizar" component={AtualizarDescricao} /> {/* Cadastrar Consulta */}
        <Route path="/mapa" component={Localizacao} />
        <Route path="/notFound" component={NotFound} /> {/* Not Found */}
        <Redirect to="/notFound" />
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
