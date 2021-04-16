$('.Lista').change(function GetConteudo(texto) {
    // Buscando Listas pelo ID
    var ListaEspecialidade = document.getElementById("ListaEspecialidades");
    var ListaUF = document.getElementById("ListaUF");

    // Pegando Valor Selecionado
    var valorselecionado = ListaUF.options[ListaUF.selectedIndex].value;
    var valorselecionado1 = ListaEspecialidade.options[ListaEspecialidade.selectedIndex].value;

    // Pegando a Lista de classes
    var conteudo = texto.target.classList;

    if (conteudo.contains("ListaUF") & !(conteudo.contains("Alterada"))) {

        GetCidades(valorselecionado);

    } else if (conteudo.contains("ListaUF") & conteudo.contains("Alterada")) {

        GetCidadesEsp(valorselecionado1, valorselecionado)

    } else if (conteudo.contains("ListaEspecialidades")) {

        GetUFs(valorselecionado1);
        GetCidade(valorselecionado1);
    }

});
//Funções ---
function GetCidadesEsp(Especialidade, UF) {
    var Especialidade = Especialidade
    var UF = UF
    $.ajax({
        type: 'GET',
        url: '/Inicio/RecarregarCidadesEsp',
        data: { Especialidade: Especialidade, UF: UF },
        dataType: "json",
    }).done(function (result) {
        var IDLista = document.getElementById("ListaCidade");
        ReescreverLista(result, IDLista)
    });
}
function GetUFs(conteudo) {
    var Especialidade = conteudo;
    $.ajax({
        type: 'GET',
        url: '/Inicio/RecarregarUFs',
        data: { Especialidade: Especialidade },
        dataType: "json"
    }).done(function (result) {
        var IDLista = document.getElementById("ListaUF");
        IDLista.classList.add("Alterada");
        ReescreverLista(result, IDLista)
    });
}
function GetCidade(conteudo) {
    var Especialidade = conteudo;
    $.ajax({
        type: 'GET',
        url: '/Inicio/RecarregarCidade',
        data: { Especialidade: Especialidade },
        dataType: "json"
    }).done(function (result) {
        var IDLista = document.getElementById("ListaCidade");
        ReescreverLista(result, IDLista)
    });
}
function GetCidades(conteudo) {
    var Estado = conteudo;
    $.ajax({
        type: 'GET',
        url: '/Inicio/RecarregarCidades',
        data: { Estado: Estado },
        dataType: "json"
    }).done(function (result) {
        var IDLista = document.getElementById("ListaCidade");
        ReescreverLista(result, IDLista)
    });
}
function ReescreverLista(Lista, IDLista) {
    IDLista.innerHTML = null
    Lista.forEach(function (item) {
        IDLista.innerHTML += '<option value="' + item + '"class="Cidade">' + item + '</option>'
    })
}
$("#buscar").click(function GetProfissionais() {
    var IDEspecialidade = document.getElementById("ListaEspecialidades");
    var UF = document.getElementById("ListaUF");
    var Cidade = document.getElementById("ListaCidade")
    IDEspecialidade= IDEspecialidade.options[IDEspecialidade.selectedIndex].value;
    UF= UF.options[UF.selectedIndex].value;
    Cidade= Cidade.options[Cidade.selectedIndex].value;
    $.ajax({
        type: 'GET',
        url: '/Inicio/RecarregarProfissionais',
        data: { IDEspecialidade: IDEspecialidade, UF: UF, Cidade: Cidade },
        dataType: "json",
    }).done(function (result) {
        var IDList = document.getElementById("ListaProfissionais");
        IDList.innerHTML = null;
        result.forEach(function (item) {
            if (item.imagem == null) {
                IDList.innerHTML += '<div class="offset-1 offset-md-0 col-md-3 col-sm-6 col-10" id="Profissionais">' +
                    '<div class="card mb-4 shadow-sm" >' +
                    '<!--Imagem Perfil-->' +
                    '<img class="img-thumbnail" src="/Images/perfil_foto_padrão.jpg" style="width: 250px; height: 200px;padding:0;" alt="" />' +
                    '<!--Imagem Perfil-->' +
                    '<div class="card-body" style="padding:8px;">' +
                    '<p style="font-size:12px;margin:0;">' +
                    '<b>Nome : </b>' + item.nome + '<br />' +
                    '<b>Sobrenome : </b>' + item.sobrenome + '<br />' +
                    '<b>Telefone : </b>' + item.telefone + '<br />' +
                    '<b>Cidade : </b>' + item.cidade +
                    '</p>' +
                    '<a href="/Inicio/Detalhes/' + item.id + '" class="btn-link" style="padding:2px;margin:0;font-size:12px;">Mais informações</a>' +
                    '</div>' +
                    '</div>' +
                    '</div >'
            } else {
                IDList.innerHTML += '<div class="offset-1 offset-md-0 col-md-3 col-sm-6 col-10" id="Profissionais">' +
                    '<div class="card mb-4 shadow-sm" >' +
                    '<!--Imagem Perfil-->' +
                    '<img class="img-thumbnail imagemPerfil" src="/Imagens/VerImagem/' + item.id + '" alt="" />' +
                    '<!--Imagem Perfil-->' +
                    '<div class="card-body" style="padding:8px;">' +
                    '<p style="font-size:12px;margin:0;">' +
                    '<b>Nome : </b>' + item.nome + '<br />' +
                    '<b>Sobrenome : </b>' + item.sobrenome + '<br />' +
                    '<b>Telefone : </b>' + item.telefone + '<br />' +
                    '<b>Cidade : </b>' + item.cidade +
                    '</p>' +
                    '<a href="/Inicio/Detalhes/' + item.id + '" class="btn-link" style="padding:2px;margin:0;font-size:12px;">Mais informações</a>' +
                    '</div>' +
                    '</div>' +
                    '</div >'
            }
            
         })

    })
})
//Funções ---