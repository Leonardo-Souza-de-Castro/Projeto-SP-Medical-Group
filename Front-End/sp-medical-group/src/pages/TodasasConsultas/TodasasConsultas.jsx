import { useState, useEffect } from 'react'
import axios from 'axios'

import imagem_banner from '../../assets/img/undraw_Browsing_online_re_umsa 1.svg'
import logo from '../../assets/img/Logo_vbranca.svg'
import foto_perfil from '../../assets/img/user 1.png'

import Header from '../../components/header/header'

export default function ConsultaPaciente() {
    const [listatodasconsultas, setListastodasconsultas] = useState([]);

    // function BuscarMeusEventos() {
    //     axios('http://192.168.3.115:5000/api/Consulta/', {
    //         headers: {
    //             'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
    //         }
    //     }).then((resposta) => {
    //         if (resposta.status === 200) {
    //             console.log(resposta.data)
    //             setListastodasconsultas(resposta.data)
    //         }
    //     }).catch(erro => console.log(erro))
    // }
    // useEffect(BuscarMeusEventos, [])
    
    function BuscarMeusEventos() {
        axios('https://6205069a161670001741b35f.mockapi.io/Consulta', {

        }).then((resposta) => {
            if (resposta.status === 200) {
                console.log(resposta.data)
                setListastodasconsultas(resposta.data)
            }
        }).catch(erro => console.log(erro))
    }
    useEffect(BuscarMeusEventos, [])

    return (
        <div>
            <Header/>
            <section className="container-banner">
                <img src={imagem_banner} alt="Banner Principal" className="Img_banner"/>
                <img src={logo} alt="Logo Site" className="logo-banner" />
            </section>
            <section className="container-consultas">
                <h1>Todas as Consultas</h1>
                {
                    listatodasconsultas.map((minhaConsulta) => {
                        console.log(minhaConsulta)
                        return (
                            <div className='div-container' key={minhaConsulta.id}>
                                <section className="container-consulta">
                                    <div className="box-total" >
                                        <div className="box-paciente">
                                            <img src={foto_perfil} alt="Foto do Usuario" className="foto-perfil" />
                                            <div className="box-info-paciente">
                                                <span className="dados-consulta">{Intl.DateTimeFormat("pt-BR", {
                                                    year: 'numeric', month: 'numeric', day: 'numeric',
                                                    hour: 'numeric', minute: 'numeric',
                                                    hour12: false
                                                }).format(new Date(minhaConsulta.Data_Consulta))}</span>
                                                <span className="dados-consulta">{minhaConsulta.Id_Prontuario[0].Nome}</span>
                                                <span className="dados-consulta">{minhaConsulta.Id_Medico[0].Nome} </span>
                                            </div>
                                        </div>
                                        <div className="box-opcoes">
                                            <div className="box-status reduz-espacamento">
                                                {/* <span className="info_status">{minhaConsulta.Id_Status.Descricao}</span>
                                                {
                                                    (minhaConsulta.Id_Status === 1 ? <hr className="divisoria" /> :

                                                        minhaConsulta.Id_Status === 2 ? <hr className="divisoria-vermelha" />

                                                            : <hr className="divisoria-amarela" />)
                                                } */}
                                            </div>
                                            <div className="box-alterar-descricao">
                                                {/* <a href="Descricao.html"><img src="../assets/ferramenta-lapis 4.png" alt="Icone de Edição"/></a> */}
                                                {/* <!--Transformar essa imagem em icone depois--> */}
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
};