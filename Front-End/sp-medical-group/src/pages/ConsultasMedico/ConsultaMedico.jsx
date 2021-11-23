import { useState, useEffect, useHistory } from 'react'
import axios from 'axios'
import { Link, Redirect } from 'react-router-dom';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faEdit } from '@fortawesome/free-regular-svg-icons'

import imagem_banner from '../../assets/img/undraw_medicine_b1ol.svg'
import logo from '../../assets/img/Logo_vbranca.svg'

export default function ConsultaMedico() {
    const [listaminhasconsultas, setListasminhasconsultas] = useState([]);
    function BuscarMeusEventos() {
        axios('http://localhost:5000/api/Consulta/Medico', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then((resposta) => {
            if (resposta.status === 200) {
                console.log(resposta.data)
                setListasminhasconsultas(resposta.data)
            }
        }).catch(erro => console.log(erro))
    }
    useEffect(BuscarMeusEventos, [])

    return (
        <div>
            <section class="container-banner">
                <img src={imagem_banner} alt="Banner Principal" />
                <img src={logo} alt="Logo Site" class="logo-banner" />
            </section>
            <section class="container-consultas">
                <h1>Minhas Consultas</h1>

                {
                    listaminhasconsultas.map((minhaConsulta) => {
                        return (
                            <div className='div-container'>
                                <section class="container-consulta">
                                    <div class="box-total">
                                        <div class="box-paciente">
                                            <img src="../assets/user 1.png" alt="Foto do Usuario" class="foto-perfil" />
                                            <div class="box-info-paciente">
                                                <span className="dados-consulta">{Intl.DateTimeFormat("pt-BR", {
                                                    year: 'numeric', month: 'numeric', day: 'numeric',
                                                    hour: 'numeric', minute: 'numeric',
                                                    hour12: false
                                                }).format(new Date(minhaConsulta.dataConsulta))}</span>
                                                <span className="dados-consulta">{minhaConsulta.idProntuarioNavigation.nome}</span>
                                            </div>
                                        </div>
                                        <div class="box-opcoes">
                                            <div class="box-status reduz-espacamento">
                                                <span>{minhaConsulta.idStatusNavigation.descricao}</span>
                                                {
                                                    (minhaConsulta.idStatus === 1 ? <hr className="divisoria" /> :

                                                        minhaConsulta.idStatus === 2 ? <hr className="divisoria-vermelha" />

                                                            : <hr className="divisoria-amarela" />)
                                                }
                                            </div>
                                            <div class="box-alterar-descricao">
                                                <Link to={{pathname: '/atualizar', state: {id: minhaConsulta.idConsulta}}}><FontAwesomeIcon icon={faEdit} className="IconeAlterarDescricao" /></Link>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                            </div>
                        )
                    })
                }
            </section>
        </div>
    )
}