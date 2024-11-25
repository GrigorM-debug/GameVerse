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