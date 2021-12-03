import 'react-native-gesture-handler';

import React, {Component} from 'react'

import {NavigationContainer} from '@react-navigation/native'
import {createStackNavigator} from '@react-navigation/stack'

import {StatusBar} from 'react-native'

// Importação das telas
import Login from './src/screens/Login'
import Consultas from './src/screens/Consultas'

const AuthStack = createStackNavigator();


class App extends Component{
  render(){
    return(
      <NavigationContainer>
        
        <StatusBar/>
        <AuthStack.Navigator screenOptions={{headerShown:false}}>
        <AuthStack.Screen name="Login" component={Login}/>
        <AuthStack.Screen name="Consultas" component={Consultas}/>
        </AuthStack.Navigator>
      </NavigationContainer>
    )
  }
}
export default App;
