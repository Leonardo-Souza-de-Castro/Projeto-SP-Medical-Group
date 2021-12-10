import { Component } from "react";
import axios from 'axios';

import Header from '../../components/header/header'

export default class Descricao extends Component {
    constructor(props) {
        super(props)
        this.state = {
            consultabuscada: {},
            dataConsulta: new Date(),
            infoPaciente: {},
            infoStatus: {},
            // descricaoAtualizada: {},
            idConsulta: props.location.state.id,
            descricao: ''
        }
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    };

    buscarConsulta = () => {
        console.log(this.state.idConsulta)

        axios('http://192.168.3.115:5000/api/Consulta/' + this.state.idConsulta, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    // console.log(resposta.data)
                    console.log('Pra cima deles')
                    this.setState({ consultabuscada: resposta.data })
                };
                this.setState({ infoMedico: this.state.consultabuscada.idMedicoNavigation })
                this.setState({ infoPaciente: this.state.consultabuscada.idProntuarioNavigation })
                this.setState({ infoStatus: this.state.consultabuscada.idStatusNavigation })
                this.setState({ dataConsulta: this.state.consultabuscada.dataConsulta })
                // this.setState({descricaoAtualizada: this.state.consultabuscada.descricao})
                console.log(this.state.infoMedico)
                console.log(this.state.infoPaciente)
                console.log(this.state.infoStatus)
                // console.log(this.state.descricaoAtualizada)
            })
            .catch(erro => console.log(erro));


        //     axios.get('http://localhost:5000/api/Consulta/' + this.state.idConsulta, {
        //         headers: {
        //             Authorization: ''
        //             //Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
        //           }.then((resposta) => {
        //            if (resposta.satus === 200) {
        //                  console.log('Pra cima deles')
        //                 this.setState({ consultabuscada: resposta.data })
        //             }
        //         }).catch(erro => console.log(erro))
        //    })
    };

    atualizarDescricao = (event) => {
        event.preventDefault();

        console.log(this.state.idConsulta)
        console.log(this.state.descricao)
        const token = localStorage.getItem('usuario-login')
        axios.patch('http://192.168.3.115:5000/api/Consulta/Descricao/' + this.state.idConsulta,
            { descricao: this.state.descricao }, {
            headers: {
                'Authorization': 'Bearer ' + token
            }
        })
            .then((resposta) => {
                if (resposta.status === 200) {
                    console.log('função funciona')
                    // this.setState({ descricao: resposta.data })
                    this.props.history.push('/consultasmedico')
                }
            }).catch(erro => console.log(erro))
    };

    componentDidMount() {
        console.log(this.state.infoStatus)
        this.buscarConsulta();
        // console.log(this.state.idConsulta)
    }

    render() {
        return (
            <div>
                <Header />
                <main className="container">
                    <h1 className="titulo">Descrição da Consulta</h1>

                    {
                        <section className="container-consulta">
                            <div className="box-total">
                                <div className="box-paciente">
                                    <img src="../assets/user 1.png" alt="Foto do Usuario" className="foto-perfil" />
                                    <div className="box-info-paciente">
                                        <span className="dados-consulta">{Intl.DateTimeFormat(
                                            "pt-BR", {
                                            year: 'numeric', month: 'numeric', day: 'numeric',
                                            hour: 'numeric', minute: 'numeric',
                                            hour12: false
                                        }).format(new Date(this.state.dataConsulta))}</span>
                                        <span className="dados-consulta">Descrição: {this.state.consultabuscada.descricao}</span>
                                        <span className="dados-consulta">{this.state.infoPaciente.nome}</span>
                                    </div>
                                </div>
                                <div className="box-status">
                                    <span className="info_status">{this.state.infoStatus.descricao}</span>
                                    {
                                        (this.state.infoStatus.idStatus === 1 ? <hr className="divisoria" /> :

                                            this.state.infoStatus.idStatus === 2 ? <hr className="divisoria-vermelha" />

                                                : <hr className="divisoria-amarela" />)
                                    }
                                </div>
                            </div>
                        </section>
                    }

                    <section className="container-descricao">
                        <div className="box-info">
                            <h2>Nova Descrição:</h2>
                            <form onSubmit={this.atualizarDescricao}>
                                <textarea cols="20" rows="7" placeholder="Insira a descrição da consulta realizada aqui:"
                                    className="input-descricao" name="descricao" value={this.state.descricao} onChange={this.atualizaStateCampo}></textarea>
                                <div className="box-botao">
                                    <button className="botao-enviar" type='submit'>Enviar</button>
                                </div>
                            </form>
                        </div>
                    </section>
                </main>
            </div>
        )
    }
}