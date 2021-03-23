function GetLogradouro(cep) {
    if (ValidaCEP(cep)) {
        return
    }

    var invalido = "CEP Invalido !!"
    return invalido
}
function ValidaCEP(cep) {
    var Validacao = !(cep > 8 || CEP < 8)
    return Validacao
}