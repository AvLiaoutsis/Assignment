// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    //Hide DropDownList
    var select1 = document.getElementById('start');
    select1.style.display = 'none';

    var select2 = document.getElementById('waypoints');
    select2.style.display = 'none';

    var select3 = document.getElementById('end');
    select3.style.display = 'none';
});
function initMap() {
    var directionsService = new google.maps.DirectionsService;
    var directionsRenderer = new google.maps.DirectionsRenderer;
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 6,
        center: { lat: 41.85, lng: -87.65 }
    });
    directionsRenderer.setMap(map);

    document.getElementById('submit').addEventListener('click', function () {
        calculateAndDisplayRoute(directionsService, directionsRenderer);
    });
}

function calculateAndDisplayRoute(directionsService, directionsRenderer) {


    var takeElementParent = document.getElementById("Starter");
    var hasCar = takeElementParent.getAttribute("HasCar");


    if (hasCar == "HasCar") {
        travelmode = 'DRIVING'
    }
    else {
        travelmode = 'WALKING'
    }


    var waypts = [];
    var checkboxArray = document.getElementById('waypoints');
    for (var i = 0; i < checkboxArray.length; i++) {
        if (checkboxArray.options[i].selected) {
            waypts.push({
                location: checkboxArray[i].value,
                stopover: true
            });
        }
    }

    directionsService.route({
        origin: document.getElementById('start').value,
        destination: document.getElementById('end').value,
        waypoints: waypts,
        optimizeWaypoints: true,
        travelMode: travelmode
    }, function (response, status) {
        if (status === 'OK') {
            directionsRenderer.setDirections(response);
            var route = response.routes[0];
            var summaryPanel = document.getElementById('directions-panel');
            summaryPanel.innerHTML = '';
            // For each route, display summary information.
            for (var i = 0; i < route.legs.length; i++) {
                var routeSegment = i + 1;
                summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment +
                    '</b><br>';
                summaryPanel.innerHTML += route.legs[i].start_address + ' to ';
                summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
                summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
            }
            if (hasCar == "HasCar") {
                summaryPanel.innerHTML += "<b>Travelling by Car</b>";

            }
            else {
                summaryPanel.innerHTML += "<b>Travelling on Foot </b>";

            }
        } else {
            window.alert('Directions request failed due to ' + status);
        }
    });
}

