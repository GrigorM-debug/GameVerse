
function initializeMap(defaultLatitute, defaultLongtitude) {
    // Initialize the map
    let map = L.map('map').setView([defaultLatitude, defaultLongitude], 13); // Starting position (Sofia)

    // Add OpenStreetMap tile layer
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    // Add a marker with drag functionality
    let marker = L.marker([defaultLatitude, defaultLongitude], { draggable: true }).addTo(map);
    marker.bindPopup("Event Location!").openPopup();

    document.getElementById('latitude').value = defaultLatitude;
    document.getElementById('longitude').value = defaultLongitude;

    // Update coordinates when the marker is dragged
    marker.on('dragend', function (event) {
        let position = marker.getLatLng();
        document.getElementById('latitude').value = position.lat;
        document.getElementById('longitude').value = position.lng;
    });

    // Allow the user to click on the map to move the marker
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
                language: 'en'
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