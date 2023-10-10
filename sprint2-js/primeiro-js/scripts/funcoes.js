function calcular() {
    event.preventDefault(); // Interrompe o submit do formulário, q atualize

    let n1 = parseFloat(document.getElementById("numero1").value);
    let n2 = parseFloat(document.getElementById("numero2").value);
    let res; // undefined
    let op = document.getElementById("operacao").value;

    if (isNaN(n1) || isNaN(n2)) {
        alert("Preencha todos os campos !!!")
        return;
    }

    if (op == '+') {
        res = somar(n1, n2);
    }
    else if (op == '-') {
        res = subtrair(n1, n2);
    }
    else if (op == '*') {
        res = multiplicar(n1, n2);
    }
    else if (op == '/') {
        res = dividir(n1, n2);
    }
    else {
        res = "Operação Inválida";
    }

    // console.log(`Resultado: ${res}`);
    document.getElementById('resultado').innerText = res;

    //===============functions===============\\

    function somar(x, y) {
        return (x + y).toFixed(2); //number
    }

    function subtrair(x, y) {
        return (x - y).toFixed(2); //number
    }

    function multiplicar(x, y) {
        return (x * y).toFixed(2); //number
    }

    function dividir(x, y) {
        if (y == 0) {
            return "Impossível dividir por zero"; //text
        }
        return (x / y).toFixed(2); //pode dar infinity
        //number
    }

    // alert
    // (`Resultados: 

    // Soma: = ${parseInt(n1)+parseInt(n2)}
    // Subtração: = ${parseInt(n1)-parseInt(n2)}
    // Divisão: = ${parseInt(n1)/parseInt(n2)}
    // Multiplicação: = ${parseInt(n1)*parseInt(n2)}

    // `)
}