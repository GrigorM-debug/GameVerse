function startScanner() {
    function onSuccessCallback(decodedText) {
        alert(`Qr code successfully scanned : ${decodedText}`);
        html5QrCode.stop();
        readerDiv.style.display = "none";
        validateTicket(decodedText);
    }

    function onErrorCallback(errroMessage) {
        console.error("Error while scanning", errorMessage);
    }

    const config = { fps: 10, qrbox: { width: 250, height: 250 } };

    const readerDiv = document.getElementById("reader");
    readerDiv.style.display = "block";

    const html5QrCode = new Html5Qrcode("reader");
    html5QrCode.start(
        { facingMode: "user" },
        config,
        onSuccessCallback,
        onErrorCallback
    ).catch((err) => {
        alert("Failure to access the camera:", err);
    });
}

async function validateTicket(qrData) {
    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;

    await fetch("/Administrator/ValidateUserTicket/ValidateTicket", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': token
        },
        body: JSON.stringify({ qrData })
    })
        .then(response => response.json())
        .then(data => {
            if (data.valid) {
                alert('Ticket is valid');
            } else {
                alert('Ticket is not valid');
            }
        })
        .catch(error => console.error('Error occured while validating:', error));

}

document.getElementById('scanButton').addEventListener('click', startScanner);