//foreach - void



//-- map (retorna novo array modificado) --


// const numeros = [1, 2, 5, 10, 300];

// const dobro = numeros.map(n => n * 2);

// console.log(numeros, dobro);


//-- filter(retorna novo array apenas com elementos que atenderam a uma condição) --


// const numeros = [1, 2, 5, 10, 300];

// const maior10 = numeros.filter(e => e > 10)

// console.log(numeros, maior10);


// const comentarios = [

//     { comentario: "blablabla", exibe: true },
//     { comentario: "Evento foi uma...", exibe: false },
//     { comentario: "Ótimo evento !!!", exibe: true }

// ];

// const comentariosOk = comentarios.filter(c => c.exibe === true) // (===)Identico

// comentariosOk.forEach(x => console.log(x.comentario))


//-- reduce (retorna apenas um valor, a partir do valor inicial, colocado com parametro e no final da funcao) --


const numeros = [1, 2, 5, 10, 300];

const soma = numeros.reduce((valorInicial, numero) => {
    return valorInicial + numero
}, 20)

console.log(soma);


//-------------------------------------