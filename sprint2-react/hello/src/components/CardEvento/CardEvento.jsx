import React from "react"
import './CardEvento.css'

//"card__conectar card__conecar--disabled"

// UTILIZANDO Destructuring nas props, passando direto as props utilizadas
const CardEvento = ( {titulo, texto, desabilitado, textoLink} ) => {
    return (
        <section>

            <div className="card">

                <h1 className="card__titulo">{titulo}</h1>

                <p className="card__texto">{texto}</p>

                <p className={desabilitado ? "card__conectar card__conectar--disabled" : "card__conectar"}>{textoLink}</p> 
                {/* if para dizer se botao esta habilitado ou não, utilizando a classe para cada */}

            </div>

        </section>
    );
}

export default CardEvento;