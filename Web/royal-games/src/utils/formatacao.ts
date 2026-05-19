import { deflate } from "zlib"

const FormatarValor = (valor: number) => {
    return (
        // Preço para string da localidade pt-br  
        valor.toLocaleString("pt-br", {
            style: "currency", // moeda
            currency: "BRL"
        })
    )
}

export default FormatarValor;