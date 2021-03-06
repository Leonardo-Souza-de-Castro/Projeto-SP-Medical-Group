import { Component } from 'react';
import { Map, InfoWindow, Marker, GoogleApiWrapper } from 'google-maps-react';
// export class MapContainer extends Component {}

// export default GoogleApiWrapper({
//   apiKey: ('AIzaSyB_7NfCdKDjK9bvgmDFBBmJciuQh5awBvQ')
// })(MapContainer)

export class MapContainer extends Component {
    constructor(props) {
        super(props)
        this.state = {
            selectedPlace: ""
        }
    }
    render() {
        return (
            <Map google={this.props.google} zoom={14}>

                {/* <Marker onClick={this.onMarkerClick}
                    name={'Current location'} />

                <InfoWindow onClose={this.onInfoWindowClose}>
                    <div>
                        <h1>{this.state.selectedPlace.name}</h1>
                    </div>
                </InfoWindow> */}
            </Map>
        );
    }
}

export default GoogleApiWrapper({
    apiKey: ('AIzaSyB_7NfCdKDjK9bvgmDFBBmJciuQh5awBvQ')
})(MapContainer)