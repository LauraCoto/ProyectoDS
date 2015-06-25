var map;
var Marker;
var posicionNueva;

function localizar() {
    alert("Entro al Navigator");
    if (navigator.geolocation) {
        navigator.geolocation.watchPosition(function (position) {
            alert("Entro a las coordenas");
            document.getElementById("cordenadax").value = position.coords.latitude;
            document.getElementById("cordenaday").value = position.coords.longitude;
            
            document.getElementById("Coodernadas").value = position.coords.latitude +"," +position.coords.longitude;
        });
    }
    else {
        alert('Tu navegador no soporta la Geolocazacion');
    }




}



function init() {

    var mapOptions = {

        center: new google.maps.LatLng(15.504724701321713, -88.02433150654605),
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }

    map = new google.maps.Map(document.getElementById("mapa"), mapOptions);

    var place = new google.maps.LatLng(15.504724701321713, -88.02433150654605);
    Marker = new google.maps.Marker({
        position: place,
        map: map,
        title: 'Ubicacion',
        draggable: true
    });


    google.maps.event.addListener(Marker, "dragend", function (event) {


        document.getElementById("cordenadax").value = Marker.position.lat();
        document.getElementById("cordenaday").value = Marker.position.lng();
        document.getElementById("Coodernadas").value = Marker.position.lat() + "," + Marker.position.lng();

    });

    google.maps.event.addListener(map, "click", function (event, Marker, map) {
        alert("Estoy Escuchando");
        alert(event.latLng);

         
        

    });

}
