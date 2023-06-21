

function Amigos(){
  document.getElementById('AmigosAncora').classList.add("PostsVisiveisNoFeed");
  document.getElementById('GeralAncora').classList.remove("PostsVisiveisNoFeed");
  document.getElementById('FeedAmigos').checked = true
}
function Geral(){
  document.getElementById('AmigosAncora').classList.remove("PostsVisiveisNoFeed");
  document.getElementById('GeralAncora').classList.add("PostsVisiveisNoFeed");
  document.getElementById('FeedGeral').checked = true;
}