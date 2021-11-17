import { useState, useEffect } from 'react'
import axios from 'axios'
// import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
// import { faCoffee } from '@fortawesome/free-solid-svg-icons'

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

                {/* <Link to="/"> <FontAwesomeIcon icon={faCoffee} /> </Link> */}
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
                                                }                                            </div>
                                            <div class="box-alterar-descricao">
                                                {/* <a href="Descricao.html"><img src="../assets/ferramenta-lapis 4.png" alt="Icone de Edição"></a> */}
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