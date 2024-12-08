function startScanner() {
    function onSuccessCallback(decodedText) {
        alert(`Qr code successfully scanned : ${decodedText}`);
        html5QrCode.stop();
        readerDiv.style.display = "none";
        validateTicket(decodedText);
    }

    function onErrorCallback(errroMessage) {
        alert("Error while scanning", errorMessage);
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
            if (data.error) {
                alert(error);
            }

            if (data.valid) {
                document.getElementById('userName').textContent = data.userEventRegistrationData.userName;
                document.getElementById('fullName').textContent = data.userEventRegistrationData.fullName;
                document.getElementById('eventTopic').textContent = data.userEventRegistrationData.eventTopic;
                document.getElementById('startDate').textContent = data.userEventRegistrationData.startDate;
                document.getElementById('endDate').textContent = data.userEventRegistrationData.endDate;
                document.getElementById('numberOfTickets').textContent = data.userEventRegistrationData.numberOfTickets;
                document.getElementById('pricePaid').textContent = data.userEventRegistrationData.pricePaid;
                document.getElementById('registrationDate').textContent = data.userEventRegistrationData.registrationDate;

                document.getElementById('ticketInfo').style.display = 'block';
                alert('Ticket is valid');
            } else {
                document.getElementById('ticketInfo').style.display = 'none';
                alert('Ticket is not valid');
            }
        })
        .catch(error => {
            document.getElementById('ticketInfo').style.display = 'none';
            alert('Error occured while validating:', error)
        });

}

document.getElementById('scanButton').addEventListener('click', startScanner);