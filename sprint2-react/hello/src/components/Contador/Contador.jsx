import React, { useState } from "react"
import './Contador.css'

const Contador = () => {

    const [contador, setContador] = useState(0); //numero de dentro é o número que vai iniciar

    function handleIncrementar() {
        setContador(contador + 1);
    }
    function handleDecrementar() {
        setContador(contador === 0 ? 0 : contador - 1)
    }
    function handleReset() {
        setContador(0);
    }

    return (
        <>

            <p>{contador}</p>
            <button onClick={handleIncrementar}>Incrementar</button>
            <button onClick={handleDecrementar}>Decrementar</button>
            <button onClick={handleReset}>Reiniciar</button>
            {/* se colocar () aqui nessa chamada da funcao, ele faz ela direto, para passar parametro, encapsular fazendo () => {} + a funcao com os parametros  */}

        </>
    );
}

export default Contador;