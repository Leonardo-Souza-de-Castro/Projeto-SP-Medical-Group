import { Component } from 'react';
import axios from 'axios';

import '../../assets/css/style.css';

export default class Cadastrar extends Component {
    constructor(props) {
        super(props)
        this.state = {
            idProntuario: 0,
            idMedico: 0,
            idStatus: 3,
            idClinica: 0,
            dataConsulta: new Date(),

            listaPacientes: [],
            listaMedicos: [],
            listaClinicas: [],
            isLoading: false
        }
    }

    buscarPacientes = () => {
        axios('http://localhost:5000/api/Paciente', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaPacientes: resposta.data })
                console.log(resposta.data)
            }
        }).catch((erro) => console.log(erro))
    }

    buscarMedico = () => {
        axios('http://localhost:5000/api/Medico', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaMedicos: resposta.data })
                console.log(resposta.data)
            }
        }).catch((erro) => console.log(erro))
    }

    buscarClinica = () => {
        axios('http://localhost:5000/api/Clinica', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaClinicas: resposta.data })
            }
        }).catch((erro) => console.log(erro))
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    };

    cadastrarConsulta = (evento) => {
        evento.preventDefault();

        let consulta = {
            idProntuario: this.state.idProntuario,
            idMedico: this.state.idMedico,
            idClinica: this.state.idClinica,
            dataConsulta: this.state.dataConsulta,
            idStatus: this.state.idStatus
        }
        this.setState({ isLoading: true })
        axios.post('http://localhost:5000/api/Consulta', consulta, {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Consulta Cadastrada')
                    this.setState({ isLoading: false })
                    this.setState({
                        idProntuario: 0,
                        idMedico: 0,
                        idStatus: 3,
                        idClinica: 0,
                        dataConsulta: new Date()
                    })
                }
            })
            .catch((erro) => {
                if (erro.toJSON().status === 401) {
                    this.props.history.push('/login')
                }
                else console.log(erro)
            })
    }

    componentDidMount() {
        this.buscarClinica();
        this.buscarMedico();
        this.buscarPacientes();
    }

    render() {
        return (
            <div>
                <main>
                    <section className="container-formulario">
                        <h1>Cadastro de Consulta</h1>
                        <form action="" className="box-inputs" onSubmit={this.cadastrarConsulta}>
                            <select name="idProntuario" value={this.state.idProntuario} onChange={this.atualizaStateCampo}>
                                <option value="0" selected disabled>
                                    Selecione o Paciente
                                </option>

                                {this.state.listaPacientes.map((tema) => {
                                    return (
                                        <option key={tema.idProntuario} value={tema.idProntuario}>
                                            {tema.nome}
                                        </option>
                                    );
                                })}
                            </select>
                            <input type="datetime-local" name="dataConsulta" required="required" value={this.state.dataConsulta} onChange={this.atualizaStateCampo} />
                            <select name="idMedico" value={this.state.idMedico} onChange={this.atualizaStateCampo}>
                                <option value="0" selected disabled>
                                    Selecione o Medico
                                </option>

                                {this.state.listaMedicos.map((tema) => {
                                    return (
                                        <option key={tema.idMedico} value={tema.idMedico}>
                                            {tema.nome}
                                        </option>
                                    );
                                })}
                            </select>
                            <select name="idClinica" value={this.state.idClinica} onChange={this.atualizaStateCampo}>
                                <option value="0" selected disabled>
                                    Selecione a Clinica
                                </option>

                                {this.state.listaClinicas.map((tema) => {
                                    return (
                                        <option key={tema.idClinica} value={tema.idClinica}>
                                            {tema.nomeFantasia}
                                        </option>
                                    );
                                })}
                            </select>
                            {
                                this.state.isLoading === true ? <button disabled>Cadastrando...</button> : <button className="Entrando">Cadastrar</button>
                            }
                        </form>
                    </section>
                </main>
            </div>
        )
    }
}