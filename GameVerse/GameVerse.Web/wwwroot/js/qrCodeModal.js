let modal = document.getElementById('qrModal');
let modalImg = document.getElementById('qrModalImg');
let captionText = document.getElementById('caption');
let span = document.getElementsByClassName("close")[0];
let qrCoceImages = document.querySelectorAll('.qr-image');

qrCoceImages.forEach((img) => {
    img.addEventListener('click', () => {
        modal.style.display = 'block';
        modalImg.src = img.src;
    });
});

span.onclick = () => {
    modal.style.display = 'none';
};

window.onclick = (event) => {
    if (event.target == modal) {
        modal.style.display = 'none';
    }
};