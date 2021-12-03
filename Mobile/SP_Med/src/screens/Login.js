import React, { Component } from 'react'

import LinearGradient from 'react-native-linear-gradient';

import {
    Text,
    TextInput,
    Image,
    TouchableOpacity,
    StyleSheet,
    View
} from 'react-native'

import AsyncStorage from '@react-native-async-storage/async-storage'

import api from '../services/api'

export default class Login extends Component {
    constructor(props) {
        super(props)
        this.state = {
            email: "",
            senha: ""
        }
    }

    Logar = async () => {

        // console.warn(this.state.email, this.state.senha)

        const resposta = await api.post('/Login', {
            email: this.state.email,
            senha: this.state.senha,
        })

        // console.warn(resposta)
        const token = resposta.data.token
        // console.warn(token);
        await AsyncStorage.setItem('userToken', token)

        if (resposta.status == 200) {
            this.props.navigation.navigate('Consultas');
        }

    }

    render() {
        return (
            <LinearGradient colors={['#9F90E5', '#669AFA']} style={styles.Fundo}>
                <View style={styles.Container}>
                    <Image
                        source={require('../../assets/logo.png')}
                    />

                    <View style={styles.Box_Form}>
                        <TextInput
                            placeholder="Email:"
                            placeholderTextColor='white'
                            keyboardType="email-address"
                            onChangeText={email => this.setState({ email })}
                            style={styles.InputLogin}
                        />

                        <TextInput
                            placeholder="Senha:"
                            placeholderTextColor='white'
                            keyboardType="default"
                            secureTextEntry={true}
                            onChangeText={senha => this.setState({ senha })}
                            style={styles.InputLogin}
                        />

                        <TouchableOpacity
                            onPress={this.Logar}
                            style={styles.BotaoLogin}
                            >
                            <Text style={styles.TextoBotao}>Entrar</Text>
                        </TouchableOpacity>
                    </View>
                </View>
            </LinearGradient>
        )
    }
}

const styles = StyleSheet.create({
    Fundo: {
        flex: 1,
    },

    Container:{
        flex: 1,
        alignItems: 'center',
        justifyContent: 'center'
    },

    Box_Form:{
        borderColor: 'white',
        borderWidth: 2,
        borderRadius: 12,
        width: '85%',
        height: '60%',
        justifyContent: 'space-evenly',
        alignItems: 'center'
    },

    InputLogin:{
        borderColor: 'white',
        borderWidth: 2,
        borderRadius: 12,
        width: '90%',
        fontFamily: 'Open Sans',
        fontWeight: '600',
        color: 'white'
    },

    BotaoLogin: {
        backgroundColor: '#8B5EDB',
        width: '90%',
        height: '10%',
        alignItems: 'center',
        justifyContent: 'center'
    },

    TextoBotao:{
        color: 'white',
        fontFamily: 'Open Sans',
        fontWeight: 'bold',
        fontSize: 14
    }
})