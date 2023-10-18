// const somar = (x, y) => {
//     return x + y;
// }

// console.log(somar(50, 10));

// const dobro = (x) => {
//     return x * 2;
// }

//se tiver apenas um parametro, posso omitir os parenteses dele
// const dobro = x => {
//     return x * 2;
// }

//se tiver apenas uma linha, posso omitir as chaves e o 'return'.
// const dobro = x => x * 2;

// const boaTarde = () => { console.log("Boa Tarde !!!"); }
// boaTarde();

const convidados = [
    { nome: "Carlos", idade: 36 },
    { nome: "Claiton", idade: 43 },
    { nome: "Guilherme Henrique", idade: 18 }
];

//forEach com arrow function [sem parenteses se tiver apenas um parametro]

convidados.forEach(p => {
    console.log(`Convidado: ${p.nome} || Idade: ${p.idade}`)
})