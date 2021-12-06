import { useState, useEffect } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faEdit } from '@fortawesome/free-regular-svg-icons'

import imagem_banner from '../../assets/img/undraw_medicine_b1ol.svg'
import logo from '../../assets/img/Logo_vbranca.svg'

export default function ConsultaMedico() {
    const [listaminhasconsultas, setListasminhasconsultas] = useState([]);
    function BuscarMeusEventos() {
        axios('http://192.168.3.115:5000/api/Consulta/Medico', {
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
            <section className="container-banner">
                <img src={imagem_banner} alt="Banner Principal" />
                <img src={logo} alt="Logo Site" className="logo-banner" />
            </section>
            <section className="container-consultas">
                <h1>Minhas Consultas</h1>

                {
                    listaminhasconsultas.map((minhaConsulta) => {
                        return (
                            <div className='div-container' key={minhaConsulta.idConsulta}>
                                <section className="container-consulta">
                                    <div className="box-total">
                                        <div className="box-paciente">
                                            <img src="../assets/user 1.png" alt="Foto do Usuario" className="foto-perfil" />
                                            <div className="box-info-paciente">
                                                <span className="dados-consulta">{Intl.DateTimeFormat("pt-BR", {
                                                    year: 'numeric', month: 'numeric', day: 'numeric',
                                                    hour: 'numeric', minute: 'numeric',
                                                    hour12: false
                                                }).format(new Date(minhaConsulta.dataConsulta))}</span>
                                                <span className="dados-consulta">{minhaConsulta.idProntuarioNavigation.nome}</span>
                                            </div>
                                        </div>
                                        <div className="box-opcoes">
                                            <div className="box-status reduz-espacamento">
                                                <span>{minhaConsulta.idStatusNavigation.descricao}</span>
                                                {
                                                    (minhaConsulta.idStatus === 1 ? <hr className="divisoria" /> :

                                                        minhaConsulta.idStatus === 2 ? <hr className="divisoria-vermelha" />

                                                            : <hr className="divisoria-amarela" />)
                                                }
                                            </div>
                                            <div className="box-alterar-descricao">
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