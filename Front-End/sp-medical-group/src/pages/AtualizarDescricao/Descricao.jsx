import { Component } from "react";
import axios from 'axios';

export default class Descricao extends Component {
    constructor(props) {
        super(props)
        this.state = {
            consultabuscada: [],
            idConsulta: props.location.state.id,
            descricao: ''
        }
    }

    buscarConsulta = () => {
        axios.get('http://localhost:5000/api/Consulta' + this.state.idConsulta, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }.then((resposta) => {
                if (resposta.satus === 200) {
                    console.log('Pra cima deles')
                    this.setState({ consultabuscada: resposta.data })
                }
            })
        })
    }

    atualizarDescricao = () => {
        axios.put('http://localhost:5000/api/Consulta' + this.state.idConsulta, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }.then((resposta) => {
                if (resposta.status === 200) {
                    console.log('função funciona')
                    this.setState({ descricao: resposta.data })
                }
            }).catch(erro => console.log(erro))
        })
    }

    render() {
        return (
            <div>
                <main class="container">
                    <h1 class="titulo">Descrição da Consulta</h1>
                    <section class="container-consulta">
                        <div class="box-total">
                            <div class="box-paciente">
                                <img src="../assets/user 1.png" alt="Foto do Usuario" class="foto-perfil" />
                                <div class="box-info-paciente">
                                    <span>{Intl.DateTimeFormat("pt-BR", {
                                        year: 'numeric', month: 'numeric', day: 'numeric',
                                        hour: 'numeric', minute: 'numeric',
                                        hour12: false
                                    }).format(new Date(this.state.consultabuscada.dataConsulta))}</span>
                                    <span className="dados-consulta">{this.state.consultabuscada.idProntuarioNavigation.nome}</span>
                                </div>
                            </div>
                            <div class="box-status">
                                <span>{this.state.consultabuscada.idStatusNavigation.descricao}</span>
                                {
                                    (this.state.consultabuscada.idStatus === 1 ? <hr className="divisoria" /> :

                                        this.state.consultabuscada.idStatus === 2 ? <hr className="divisoria-vermelha" />

                                            : <hr className="divisoria-amarela" />)
                                }
                            </div>
                        </div>
                    </section>
                    )
                    <section class="container-descricao">
                        <div class="box-info">
                            <h2>Nova Descrição:</h2>
                            <form type='submit'>
                                <textarea cols="20" rows="7" placeholder="Insira a descrição da consulta realizada aqui:"
                                    class="input-descricao"></textarea>
                                <div class="box-botao">
                                    <button class="botao-enviar">Enviar</button>
                                </div>
                            </form>
                        </div>
                    </section>
                </main>
            </div >
        )
    }
}