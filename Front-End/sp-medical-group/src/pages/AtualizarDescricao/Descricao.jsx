import { Component } from "react";
import axios from 'axios';

export default class Descricao extends Component {
    constructor(props) {
        super(props)
        this.state = {
            consultabuscada: {},
            dataConsulta: new Date(),
            infoPaciente: {},
            infoStatus: {},
            idConsulta: props.location.state.id,
            descricao: ''
        }
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    };

    buscarConsulta = () => {
        console.log(this.state.idConsulta)
        axios('http://192.168.15.6:5000/api/Consulta/' + this.state.idConsulta, {
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
                this.setState({infoMedico: this.state.consultabuscada.idMedicoNavigation})
                this.setState({infoPaciente: this.state.consultabuscada.idProntuarioNavigation})
                this.setState({infoStatus: this.state.consultabuscada.idStatusNavigation})
                this.setState({dataConsulta: this.state.consultabuscada.dataConsulta})
                // console.log(this.state.infoMedico)
                // console.log(this.state.infoPaciente)
                // console.log(this.state.infoStatus)
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

    atualizarDescricao = () => {
        axios.put('http://192.168.15.6:5000/api/Consulta/' + this.state.idConsulta, this.state.descricao, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }.then((resposta) => {
                if (resposta.status === 200) {
                    console.log('função funciona')
                    // this.setState({ descricao: resposta.data })
                }
            }).catch(erro => console.log(erro))
        })
    };

    componentDidMount() {
        this.buscarConsulta();
    }

    render() {
        return (
            <div>
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
                                        <span className="dados-consulta">{this.state.infoPaciente.nome}</span>
                                    </div>
                                </div>
                                <div className="box-status">
                                    <span>{this.state.infoStatus.descricao}</span>
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
                            <form type='submit'>
                                <textarea cols="20" rows="7" placeholder="Insira a descrição da consulta realizada aqui:"
                                    className="input-descricao" name="descricao" value={this.state.descricao} onChange={this.atualizaStateCampo}></textarea>
                                <div className="box-botao">
                                    <button className="botao-enviar" onClick={this.atualizarDescricao}>Enviar</button>
                                </div>
                            </form>
                        </div>
                    </section>
                </main>
            </div>
        )
    }
}