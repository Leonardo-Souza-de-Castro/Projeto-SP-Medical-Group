import { Component } from "react";
import axios from axios;

export default class Descricao extends Component{
    constructor(props){
        super(props)
        this.state = {
            idConsulta: 0,
            descricao: ''
        }
    }

    atualizarDescricao = () => {
        axios.put('http://localhost:5000/api/Consulta' + this.state.idConsulta, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }.then((resposta) => {
                if (resposta.status === 200) {
                    console.log('função funciona')
                    this.setState({descricao: resposta.data})
                }
            }).catch(erro => console.log(erro))
        })
    }

    render(){
        return(
            <div>
                <textarea name="" id="" cols="30" rows="10"></textarea>
            </div>
        )
    }
}