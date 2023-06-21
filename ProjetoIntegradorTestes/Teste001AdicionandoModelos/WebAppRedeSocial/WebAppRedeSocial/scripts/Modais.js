function Escolha(){
    var obj = document.getElementById('GrupoOuPostagem')
    obj.style.visibility = "visible";
    obj.style.backgroundColor = 'rgba(0, 0, 0, 0.5)';

}
function FecharEscolha(){
    var obj = document.getElementById('GrupoOuPostagem')
    obj.style.visibility = "hidden";
    obj.style.backgroundColor = 'rgba(0, 0, 0, 0)';
}

function CriarPostagemModal(){

    var obj = document.getElementById('CriarPostagem')
    obj.style.visibility = "visible";
    obj.style.backgroundColor = 'rgba(0, 0, 0, 0.5)';
}
function FecharPostagemModal(){
    var obj = document.getElementById('CriarPostagem')
    obj.style.visibility = "hidden";
    obj.style.backgroundColor = 'rgba(0, 0, 0, 0)';
}

function AbrirArquivos(){
    var InputArquivo = document.getElementById("InputDaMidia");
    var SpanDaImage = document.getElementById('ImagemSelecionada');
    InputArquivo.click();  
    InputArquivo.addEventListener("change", function() {
        const nome = InputArquivo.files[0].name; 
        SpanDaImage.textContent = "Foto: " + nome ; 
        SpanDaImage.style.color = "grey";
    });
}
