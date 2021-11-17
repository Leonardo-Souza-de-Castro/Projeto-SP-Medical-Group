import { useState, useEffect } from 'react'
import axios from 'axios'

import '../../assets/css/style.css'

import imagem_banner from '../../assets/img/undraw_doctor_kw5l.svg'
import logo from '../../assets/img/Logo_vbranca.svg'
import mapa from '../../assets/img/Group 1.png'

export default function ConsultaPaciente() {
    const [listaminhasconsultas, setListasminhasconsultas] = useState([]);

    function BuscarMeusEventos() {
        axios('http://localhost:5000/api/Consulta/Paciente', {
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
                        console.log(minhaConsulta)
                        //debugger

                        console.log("aki: " + minhaConsulta.idStatus)
                        // teste(minhaConsulta)

                        return (
                            <section className="container-consulta">
                                <div className="box-total">
                                    <div className="box-paciente">
                                        <img src={mapa} alt="Local da Consulta" className="local-consulta" />
                                        <div className="box-info-paciente">
                                            <span className="dados-consulta">{minhaConsulta.idMedicoNavigation.idClinicaNavigation.endereco}</span>
                                            <span className="dados-consulta">{Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric', month: 'numeric', day: 'numeric',
                                                hour: 'numeric', minute: 'numeric',
                                                hour12: false
                                            }).format(new Date(minhaConsulta.dataConsulta))}</span>
                                            <span className="dados-consulta">{minhaConsulta.idMedicoNavigation.nome} / {minhaConsulta.idMedicoNavigation.idEspecialidadeNavigation.nomeEspecialidade}</span>
                                        </div>
                                    </div>
                                    <div className="box-status">
                                        <span>{minhaConsulta.idStatusNavigation.descricao}</span>

                                        {
                                            (minhaConsulta.idStatus === 1 ? <hr className="divisoria" /> :

                                                minhaConsulta.idStatus === 2 ? <hr className="divisoria-vermelha" />

                                                    : <hr className="divisoria-amarela" />)
                                        }
                                    </div>
                                </div>
                            </section>
                        )
                    })
                }

            </section>
        </div>
    )
};