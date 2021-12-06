import React, { Component } from 'react'

import AsyncStorage from '@react-native-async-storage/async-storage'
import LinearGradient from 'react-native-linear-gradient';


import {
    View,
    Text,
    FlatList,
    StyleSheet
} from 'react-native'

import api from '../services/api'

export default class Consultas extends Component {
    constructor(props) {
        super(props)
        this.state = {
            MinhasConsultas: []
        }
    }

    Buscarminhas = async () => {
        const token = await AsyncStorage.getItem('userToken')

        const resposta = await api.get('/Consulta/Medico', {
            headers: {
                Authorization: 'Bearer ' + token,
            }
        })
        if (resposta.status == 200) {
            // console.warn('teste')
            const dadosDaApi = resposta.data;
            // console.warn(resposta.data)
            this.setState({ MinhasConsultas: dadosDaApi })
        }

    }

    componentDidMount() {
        this.Buscarminhas()
    }

    render() {
        return (
            <LinearGradient colors={['#9F90E5', '#669AFA']} style={styles.Fundo}>
                <View style={styles.Container}>
                    <Text style={styles.Titulo}>Minhas Consultas</Text>

                    <FlatList
                        contentContainerStyle={styles.mainBodyContent}
                        data={this.state.MinhasConsultas}
                        keyExtractor={item => item.idConsulta}
                        renderItem={this.renderItem}
                    />
                </View>
            </LinearGradient>
        )
    }

    renderItem = ({ item }) => (
        <View style={styles.box_conteudo}>
            <View style={styles.box_info}>
                <Text style={styles.info}>{Intl.DateTimeFormat("pt-BR", {
                                year: 'numeric', month: 'numeric', day: 'numeric',
                                hour: 'numeric', minute: 'numeric',
                                hour12: true                                                
                            }).format(new Date(item.dataConsulta))}</Text>
                <Text style={styles.info}>{item.idProntuarioNavigation.nome}</Text>
            </View>

            <View style={styles.status_verde}>
                <Text style={styles.info}>{item.idStatusNavigation.descricao}</Text>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    Fundo: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center'
    },

    Container: {
        // backgroundColor: 'white',
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        // height: '100%'
    },

    mainBodyContent: {
        width: "100%",
        // paddingTop:10,
        // backgroundColor:"green"
        // height: '80%',
        // justifyContent: 'flex-start'
        // backgroundColor: 'white' 
    },

    Titulo: {
        fontFamily: 'Open Sans',
        fontWeight: 'bold',
        color: 'white',
        fontSize: 30,
        marginTop: '10%',
        marginBottom: '10%'
    },

    box_conteudo: {
        // backgroundColor: 'white',
        flexDirection: 'row',
        // alignItems: 'center',
        // justifyContent: 'space-evenly',
        width: '90%',
        height: 120,
        borderBottomColor: 'white',
        borderBottomWidth: 1,
        marginBottom: '30%'
    },

    box_info: {
        // backgroundColor: 'white',
        width: '75%',
        height: '100%',
        justifyContent: 'space-between'
        // alignItems: 'center'
        // flex: 0.25
    },

    info: {
        fontFamily: 'Open Sans',
        fontWeight: 'bold',
        fontSize: 20,
        color: 'white'
    },

    status_verde: {
        // backgroundColor: 'white',
        height: '30%',
        borderBottomWidth: 5,
        borderBottomColor: '#2BA301'
    },

    status_amarelo: {
        // backgroundColor: 'white',
        height: '30%',
        borderBottomWidth: 5,
        borderBottomColor: '#B8B106'
    },

    status_vermelho: {
        // backgroundColor: 'white',
        height: '30%',
        borderBottomWidth: 5,
        borderBottomColor: '#B80606'
    },

})