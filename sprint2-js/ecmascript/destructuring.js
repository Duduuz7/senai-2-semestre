const camisaLacoste = {
    descricao: 'Camisa Lacoste',
    preco: 399.98,
    marca: 'Lacoste',
    tamanho: 'G',
    cor: 'Azul',
    promo: true
}

const { descricao, preco, promo } = camisaLacoste; // dentro do objeto eu extraio somente o que eu quero, colocando o que quero nas chaves, automaticamente vira variaveis separadas

function promoSimNao() {
    if (promo == true) {
        return "Sim";
    }
    else {
        return "Não";
    }
}

console.log(`
    Produto: ${descricao}
    Preço: R$${preco}
    Promoção: ${promo ? "Sim" : "Não"} 
`);

//if ternário Promo "? // :";



const evento = {
    dataEvento: new Date(),
    descricaoEvento: "Aulão JavaScript.",
    titulo: "Iniciando no JavaScript",
    presenca: true,
    comentario: "A aula foi uma maravilha !!!"
}

const { dataEvento, descricaoEvento, titulo, presenca, comentario } = evento;

console.log(`
    Evento: ${titulo}
    Descrição: ${descricaoEvento}
    Data: ${dataEvento}
    PResençã: ${presenca ? 'Confirmada' : 'Não'}
    Comentário: ${comentario}
`);



/*

asdasd

*/ 