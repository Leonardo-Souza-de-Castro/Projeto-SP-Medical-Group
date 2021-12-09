import Logo from '../../assets/img/spmedicallogo.png';
import Menu from '../../assets/img/menu.png';

import '../../assets/css/header.css'

import { parsejwt, UsuarioAutenticado } from '../../services/Auth';

import React, { Component } from "react";
import { Link } from 'react-router-dom';

export default class Header extends Component {

    toggleMenu = () => {
        const nav = document.getElementById('nav');
        nav.classList.toggle('active');
    }

    listar = () => { 
        
        console.log("logou")


if(parsejwt() != null){



    switch (parsejwt().role) {
        case '3':
            // verifica se o usuário logado é do tipo paciente
            window.location.href = "/consultaspaciente"
            console.log('estou logado: ' + UsuarioAutenticado())
            
            break;
            case '1':
                // verifica se o usuário logado é do tipo administrador
                window.location.href = "/todasasconsultas"
            console.log('estou logado: ' + UsuarioAutenticado())

            break;
        case '2':
            // verifica se o usuário logado é do tipo médico
            window.location.href = "/consultasmedico"
            console.log('estou logado: ' + UsuarioAutenticado())
            break;
        default:
            window.location.href = "/login"
            console.log('estou logado: ' + UsuarioAutenticado())
            break;
    }

}else{
    alert("Usuario nao está logado.")
}

       
    }

    render() {

        return (
            <header>
                <div className="container container_header">
                    <button id="btnMenu" onClick={() => this.toggleMenu()} >
                        <img className="menu-hamb" src={Menu} alt="Menu Hamburguer" />
                    </button>
                    <nav id="nav">
                        <ul id="menu">
                            {/* <Link to="/">Home</Link> */}
                            <Link to="/cadastrar">Cadastrar</Link>
                            <button onClick={() => this.listar()}>Listar</button>   
                            
                        </ul>

                    </nav>
                    <Link to="/"><img className="logo" src={Logo} alt="Logo completo" /></Link>
                    <span></span>
                    <Link to="/login" className="login">{this.props.Login}</Link>
                </div>
            </header>

        )
    }
}