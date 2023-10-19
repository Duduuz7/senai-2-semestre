const evento = {
    dataEvento: new Date(),
    descricao: "Venha aprender JavaScript e todo seu poder!!",
    titulo: "Mão na massa EcmaScript",
    presenca: true,
    comentario: "Gostei do evento"
}


//---------- REST -------------

const { dataEvento, descricao, titulo, ...restoEvento } = evento; /// 3 pontinhos mais um nome cria uma propriedade com o resto do objeto q nao foi usado ali

console.log(titulo);
console.log(descricao);
console.log(dataEvento);
console.log(restoEvento);

//-----------------------------