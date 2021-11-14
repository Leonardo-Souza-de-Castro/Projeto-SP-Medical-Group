import { useState, useEffect } from 'react'
import axios from 'axios'

export default function ConsultaPaciente() {
    const [listatodasconsultas, setListastodasconsultas] = useState([]);

    function BuscarMeusEventos() {
        axios('http://localhost:5000/api/Consulta/Paciente', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
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
            {
                listatodasconsultas.map((minhaConsulta) => {
                    return (
                        <span key={minhaConsulta.idConsulta}>{minhaConsulta.idConsulta}</span>
                    )
                })
            }          
        </div>
    )
};