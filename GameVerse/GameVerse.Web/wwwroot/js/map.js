
function initializeMap(defaultLatitute, defaultLongtitude) {
    let map = L.map('map').setView([defaultLatitude, defaultLongitude], 13); // Starting position (Sofia)

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    let marker = L.marker([defaultLatitude, defaultLongitude], { draggable: true }).addTo(map);
    marker.bindPopup("Event Location!").openPopup();

    document.getElementById('latitude').value = defaultLatitude;
    document.getElementById('longitude').value = defaultLongitude;

    marker.on('dragend', function (event) {
        let position = marker.getLatLng();
        document.getElementById('latitude').value = position.lat;
        document.getElementById('longitude').value = position.lng;
    });

    map.on('click', function (event) {
        marker.setLatLng(event.latlng);
        document.getElementById('latitude').value = event.latlng.lat;
        document.getElementById('longitude').value = event.latlng.lng;
    });
}

function displayMapWithDetails(eventLat, eventLng) {
    const map = L.map('map').setView([eventLat, eventLng], 13);

    map.addControl(new L.Control.Fullscreen({
        title: {
            'false': 'View Fullscreen',
            'true': 'Exit Fullscreen'
        }
    }));

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    const eventMarker = L.marker([eventLat, eventLng]).addTo(map);
    eventMarker.bindPopup("Event Location!").openPopup();

    //Using JS Navigator
    navigator.geolocation.getCurrentPosition(
        (position) => {
            const userLat = position.coords.latitude;
            const userLng = position.coords.longitude;
            const userMarker = L.marker([userLat, userLng]).addTo(map);
            userMarker.bindPopup("You are here!").openPopup();

            const userLocation = L.latLng(userLat, userLng);
            const eventLocation = L.latLng(eventLat, eventLng);

            L.Routing.control({
                waypoints: [
                    L.latLng(userLat, userLng),
                    L.latLng(eventLat, eventLng)
                ],
                routeWhileDragging: true,
                language: 'en',
                altLineOptions: { color: 'blue', opacity: 0.7 },
                showAlternatives: true
            })
                .on('routesfound', function (e) {
                    const routes = e.routes;
                    alert(`Found ${routes.length} from your location to the Event location`)
                })
                .on('routeselected', function (e) {
                    const route = e.route;

                    const summary = route.summary;
                    const distance = summary.totalDistance;
                    const time = summary.totalTime;

                    const hours = Math.floor(time / 3600);
                    const minutes = Math.floor((time % 3600) / 60);

                    const coordinates = route.coordinates;

                    const waypoints = coordinates
                        .filter((_, index) => index % 10 === 0) 
                        .slice(1, -1) 
                        .map(coord => `${coord.lat},${coord.lng}`)
                        .join('|'); 


                    const googleMapsUrl = `https://www.google.com/maps/dir/?api=1&origin=${coordinates[0].lat},${coordinates[0].lng}&destination=${coordinates[coordinates.length - 1].lat},${coordinates[coordinates.length - 1].lng}&waypoints=${waypoints}&travelmode=driving`;

                    const navigateButton = L.control({ position: 'bottomright' });

                    navigateButton.onAdd = function () {
                        const divElement = L.DomUtil.create('div', 'navigate-button');
                        divElement.innerHTML = `<a href="${googleMapsUrl}" target="_blank" class="btn btn-primary">Open in Google Maps</a>`;
                        return divElement;
                    }

                    navigateButton.addTo(map);

                    L.popup()
                        .setLatLng(eventLocation)
                        .setContent(`Route distance: ${(distance / 1000).toFixed(2)} km<br>
                            Estimated time: ${hours} h ${minutes} min`)
                        .openOn(map);
                })
                .addTo(map);
        },
        (error) => {
            alert("Failed to get your location")
        }
    )
}

