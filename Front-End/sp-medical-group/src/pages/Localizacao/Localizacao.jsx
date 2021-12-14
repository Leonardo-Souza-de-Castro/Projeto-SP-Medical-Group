import { Component } from 'react';
import axios from 'axios';

export default class Localizacao extends Component {
    constructor(props) {
        super(props)
    }

    src="http://maps.google.com/maps/api/js?sensor=false"
    type="text/javascript"

    buscarLocal = () => {
        axios('http://192.168.3.115:5000//api/localizacoes')
            .then(resposta => montarMapa(resposta))
            .catch(erro => console.log(erro))

        function montarMapa(itens) {
            var map = new google.maps.Map(document.getElementById("map"), {
                zoom: 10,
                center: new google.maps.LatLng(-23.53642760296254, -46.64621432441258),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });

            var infoWindow = new google.maps.InfoWindow();

            var marker, i;

            for (i = 0; i < itens.length; i++) {
                console.log(itens[i].latitude);
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(
                        itens[i].latitude,
                        itens[i].longitude
                    ),
                    map: map
                });

                google.maps.event.addListener(
                    marker,
                    "click",
                    (function (marker, i) {
                        return function () {
                            infoWindow.setContent(itens[i].id);
                            infoWindow.open(map, marker);
                        };
                    })(marker, i)
                )
            };
        }
    }

    render(){
        return(
            <div id="map"></div>
        )
    }
}