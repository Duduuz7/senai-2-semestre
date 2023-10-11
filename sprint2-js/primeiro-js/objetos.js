let eduardo = {
    nome: "Eduardo",
    idade: 18,
    altura: 1.80
};

eduardo.peso = 60; // se fizer assim direto ele cria nova propriedade dentro do objeto

let carlos = new Object(); // forma menos usada de criar objeto

carlos.nome = 'Carlos';
carlos.idade = 36;
carlos.sobrenome = "Roque";

let pessoas = [];

pessoas.push(carlos);
pessoas.push(eduardo);

console.log(pessoas)

pessoas.forEach((f, i) => {
    console.log(`Pessoa ${i+1}`, `  Nome: `, f.nome,`  Idade: `, f.idade)
})