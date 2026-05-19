import { api } from "./apiService"

type JogoFormulario = {
    jogoId: number,
    nome: string,
    valor: number,
    descricao: string,
    statusJogo: boolean,
    imgUrl: string,
    generoIds: number[],
}

interface JogoListagem {
    jogoId: number,
    nome: string,
    valor: number,
    descricao: string,
    statusJogo: boolean,
    imgUrl: string,
    generoIds: number[],
}

export async function listarJogos() {
    try {
        const response = await api.get("Jogo")

        const jogos = response.data.map((jogo: JogoListagem) => ({
            ...jogo,
            ImageUrl: `${api.defaults.baseURL}${jogo.imgUrl}`
        }))

        jogos.forEach(jogo => {
            console.log(jogo)
        });

        let produtosAtivos = jogos.filter(
            ((j: JogoListagem) => j.statusJogo = true)

        )

        return produtosAtivos;
    } catch (error: any) {
        throw new Error(error.response.data);
    }
}