function PorMatricula(){
    var Mat = document.getElementById('RadioDesign1');
    var Ema = document.getElementById('RadioDesign2');
    Mat.style.backgroundColor = "#3CE900"
    Ema.style.backgroundColor = "transparent"
    document.getElementById('radio1').checked = true;
}
function PorEmail(){
    var Mat = document.getElementById('RadioDesign1');
    var Ema = document.getElementById('RadioDesign2');
    Mat.style.backgroundColor = "transparent"
    Ema.style.backgroundColor = "#3CE900"
    document.getElementById('radio2').checked = true;
}

function AbrirArquivos(){
    var InputArquivo = document.getElementById("ColocarFotoDePerfil");
    var SpanDaImage = document.getElementById('ImagemSelecionada');
    InputArquivo.click();  
    InputArquivo.addEventListener("change", function() {
        const nome = InputArquivo.files[0].name; 
        SpanDaImage.textContent = "Foto:" + nome ; 
        SpanDaImage.style.color = "grey";
    });
}
