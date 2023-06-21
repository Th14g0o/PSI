var IconeSelecionadoNoFeed = document.querySelector(".IconeFeedSelecionado");

var home = document.getElementById("HomeIcone");
var editar = document.getElementById("EditarIcone");
var perfil = document.getElementById("PerfilIcone");
var notificar = document.getElementById("NotificarIcone");
var pesquisar = document.getElementById("PesquisaIcone");


home.addEventListener("mouseover", function () {
    IconeSelecionadoNoFeed.classList.remove("IconeFeedSelecionado")
    home.classList.add("IconeFeedSelecionado")
    // Faça algo quando o mouse estiver sobre o elemento
});
home.addEventListener("mouseout", function () {
    home.classList.remove("IconeFeedSelecionado")
    IconeSelecionadoNoFeed.classList.add("IconeFeedSelecionado")
    // Faça algo quando o mouse sair do elemento
});

perfil.addEventListener("mouseover", function () {
    IconeSelecionadoNoFeed.classList.remove("IconeFeedSelecionado")
    perfil.classList.add("IconeFeedSelecionado")
});
perfil.addEventListener("mouseout", function () {
    perfil.classList.remove("IconeFeedSelecionado")
    IconeSelecionadoNoFeed.classList.add("IconeFeedSelecionado")
});

notificar.addEventListener("mouseover", function () {
    IconeSelecionadoNoFeed.classList.remove("IconeFeedSelecionado")
    notificar.classList.add("IconeFeedSelecionado")
});
notificar.addEventListener("mouseout", function () {
    notificar.classList.remove("IconeFeedSelecionado")
    IconeSelecionadoNoFeed.classList.add("IconeFeedSelecionado")
});

pesquisar.addEventListener("mouseover", function () {
    IconeSelecionadoNoFeed.classList.remove("IconeFeedSelecionado")
    pesquisar.classList.add("IconeFeedSelecionado")
});
pesquisar.addEventListener("mouseout", function () {
    pesquisar.classList.remove("IconeFeedSelecionado")
    IconeSelecionadoNoFeed.classList.add("IconeFeedSelecionado")
});

editar.addEventListener("mouseover", function () {
    IconeSelecionadoNoFeed.classList.remove("IconeFeedSelecionado")
    editar.classList.add("IconeFeedSelecionado")
});
editar.addEventListener("mouseout", function () {
    editar.classList.remove("IconeFeedSelecionado")
    IconeSelecionadoNoFeed.classList.add("IconeFeedSelecionado")
});

var MeuPerfilSelecionado = document.querySelector(".TipoDePostSelecionado");

var texto = document.getElementById("PostsTexto");
var midia = document.getElementById("PostsMidias");

texto.addEventListener("mouseover", function () {

    MeuPerfilSelecionado.classList.remove("TipoDePostSelecionado");
    texto.classList.add("TipoDePostSelecionado");
    // Faça algo quando o mouse estiver sobre o elemento
});
texto.addEventListener("mouseout", function () {
    texto.classList.remove("TipoDePostSelecionado");
    MeuPerfilSelecionado.classList.add("TipoDePostSelecionado");
    // Faça algo quando o mouse sair do elemento
});

midia.addEventListener("mouseover", function () {
    MeuPerfilSelecionado.classList.remove("TipoDePostSelecionado");
    midia.classList.add("TipoDePostSelecionado");
});
midia.addEventListener("mouseout", function () {
    midia.classList.remove("TipoDePostSelecionado");
    MeuPerfilSelecionado.classList.add("TipoDePostSelecionado");
});