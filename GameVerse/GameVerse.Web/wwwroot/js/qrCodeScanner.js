function startScanner() {
    const readerDiv = document.getElementById("reader");
    readerDiv.style.display = "block";

    const html5QrCode = new Html5Qrcode("reader");
    html5QrCode.start(
        { facingMode: "user" }, 
        { fps: 10, qrbox: { width: 250, height: 250 } },
        (decodedText) => {
            alert(`Qr code successfully scanned: ${decodedText}`); 
            //validateTicket(decodedText);
            html5QrCode.stop(); 
            readerDiv.style.display = "none";
            validateTicket(decodedText);
            //alert(`Qr code successfully scanned: ${decodedText}`); 
        },
        (errorMessage) => {
            console.error("Error while scanning", errorMessage);
        }
    ).catch((err) => {
        console.error("Failure to access the camera:", err);
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