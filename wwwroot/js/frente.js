let enderecoProduto = "https://localhost:5001/produtos/produto/";
var produto;
var compra = [];
var totalVenda = 0.0;
var troco = 0.0;

//Esconde o botão fechar no finalizar compra, linha 115.
$("#posvenda").hide();

//Atualiza o valor total e inclui o valor no span do modal-body no home/index linha 105.
atualizarTotal()
function atualizarTotal() {
    $("#totalVendaFinalizada").html(totalVenda);
}



// funçaõ para preencher o formulário, linha 91 deste arquivo.
function PreencherForm(dadosPreenchidos) {
    $("#campoNome").val(dadosPreenchidos.nome);
    $("#campoCategoria").val(dadosPreenchidos.categoria.nome);
    $("#campoFornecedor").val(dadosPreenchidos.fornecedor.nome);
    $("#campoPreco").val(dadosPreenchidos.precoDeVenda);

}

//função para zerar o formulário assim que for finalizado clicando no botão CONFIRMAR do Home/index
function zerarform() {
    $("#campoNome").val("");
    $("#campoCategoria").val("");
    $("#campoFornecedor").val("");
    $("#campoPreco").val("");
    $("#quantidade").val("");
}

//função para adicionar na tabela do home/index, adc produto (p) e quantidade (q); parametros passados na linha 66 deste arquivo
function adcNaTabela(p, q) {

    var produtoTemp = {};
    Object.assign(produtoTemp,produto);
    var venda = {produto: produtoTemp, quantidade: q, subtotal: produtoTemp.precoDeVenda * q};

    totalVenda += venda.subtotal;
    compra.push(venda);
    atualizarTotal()

    $("#compras").append(`<tr>
        <td>${p.id}</td>
        <td>${p.nome}</td>
        <td>${q}</td>
        <td>R$${p.precoDeVenda},00</td>
        <td>${p.medicao}</td>
        <td>R$${p.precoDeVenda * q}</td>
        <td><button class="btn btn-danger">Deletar</button></td>
    </tr>`);
}

//Função para adicionar dados na tabela pegando dados do Produto com Quantidade no formulário
$("#prodForm").on("submit", function(event){
    event.preventDefault();
    var dadosParaTabela = produto;
    var qtd = $("#quantidade").val();
    adcNaTabela(dadosParaTabela, qtd);
    zerarform();
})

//Função para pesquisar dados do produto no banco de dados via ajax -> (enderecoProduto+codProduto) url com Id do produto
//O controller que retorna o produto é: ProdutosController
$("#pesquisar").click(function() {
    var codProduto = $("#CodProduto").val();
    var endTemp = enderecoProduto+codProduto;
    $.post(endTemp, function(dados, status) {
        produto = dados;
        var med = "";
        //Há 3 medição Litro(0), Quilo(1) e Unidade(2), porém é cadastrado números.
        switch (produto.medicao) {
            case 0:
                med = "L"
                break;
            case 1:
                med = "Kg"
                break;
            case 2:
                med = "Un."
                break;
        
            default:
                med = "indefinido"
                break;
        }

        produto.medicao = med;
        PreencherForm(produto);
    }).fail(function() {
        alert("P Inválido");
    });
})

/* FINALIZAÇÃO DE VENDA  */

/* Condição para não finalizar antes de passar as compras */
$("#finalizarVendaBTN").click( function() {
    if (totalVenda <= 0) {
        alert(" Compra Inválida, passe os produtos primeiro.");
        return;
    }

/* 
    Condição para aceitar apenas Números, mesmo voltando como string do formulário;
    Verificando se o valor pago é igual ou maior que o total;
    manibulando botões do home/index
*/
    var valorPago = $("#valorPago").val();
    if (!isNaN(valorPago)) {
        valorPago = parseFloat(valorPago);
        if (valorPago >= totalVenda) {
            $("#posvenda").show();
            $("#prevenda").hide();
            $("#valorPago").prop("disabled", true);
            var _troco = valorPago - totalVenda;
            $("#valorTroco").val(troco);

            //Processando array da var compra
            compra.forEach(elemento => {
                elemento.produto = elemento.produto.id;
            });

            //Preparar um novo objeto
            var _venda_ = {total: totalVenda, troco: _troco, produtos: compra};

            $.ajax({
                type: "POST",
                url: "https://localhost:5001/Produtos/GerarVendas",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(_venda_),
                success: function (data){
                    console.log("Enviado Com sucesso");
                    console.log(data);
                }
            });
        }else{
            alert("Valor pago é muito baixo, verifique.")
        }
    }else{
        alert("Valor pago é inválido, são aceitos apenas números");
    }
});

function restaurarModal() {
    $("#posvenda").hide();
    $("#prevenda").show();
    $("#valorPago").prop("disabled", false);
    $("#valorPago").val("");
    $("#valorTroco").val("");
}

$("#fecharModal").click( function() {
    restaurarModal();
})