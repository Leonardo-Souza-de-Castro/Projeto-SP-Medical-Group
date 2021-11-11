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
import App from './pages/Home/App.js';
import Login from './pages/Login/login.jsx';
import ConsultaMedico from './pages/ConsultasMedico/ConsultaMedico.jsx';
import NotFound from './pages/notFound/notFound';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={App} /> {/* Home */}
        <Route path="/login" component={Login} /> {/* Login */}
        <Route path="/consultasmedico" component={ConsultaMedico} /> {/* Meus Eventos */}
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
