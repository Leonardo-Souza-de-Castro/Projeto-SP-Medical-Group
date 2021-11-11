import { Component} from 'react';
import axios from 'axios';
import {parsejwt} from '../../services/Auth'

export default class Login extends Component{
    constructor(props) {
         super(props)
        this.state = {
           email: '',
           senha: '',
            mensagemErro: '',
            isLoading: false
         };
    }

    efetuarLogin = (evento) =>{
        evento.preventDefault();

        this.setState({ mensagemErro: '', isLoading: true})
        axios.post('http://localhost:5000/api/Login', {
            email: this.state.email,
            senha: this.state.senha
        })
        .then(resposta => {
            if (resposta.status === 200) {
                localStorage.setItem('usuario-login', resposta.data.token);
                this.setState({isLoading: false})
                //console.log(localStorage.getItem('usuario-login'))
               switch (parsejwt().role) {
                   case '2':
                       this.props.history.push('/consultasmedico')
                       break;
                   case '3':
                    this.props.history.push('/ConsultasPaciente')
                       break;
                   case '1':
                    this.props.history.push('/TodasConsultas')
                       break;
               
                   default:
                    console.log('Ué cara')
                       break;
               }
            }
        })
        .catch(() =>{
            this.setState({
                mensagemErro: 'Email ou senha invalido',
                isLoading: false,
                email: '',
                senha: ''
            }, console.log('deu errado'))
        })
    }

    atualizaStateCampo = (campo) => {
        this.setState({[campo.target.name] : campo.target.value});
    };

    render(){
        return(
            <div>
                <form onSubmit={this.efetuarLogin}>
                <input type="text" placeholder="Email:" name="email" value={this.state.email} onChange={this.atualizaStateCampo}/>
                <input type="password" placeholder="Senha:" name="senha" value={this.state.senha} onChange={this.atualizaStateCampo}/>
                <span>{this.state.mensagemErro}</span>
                <button>Login</button>
                </form>
            </div>
        )
    }
}