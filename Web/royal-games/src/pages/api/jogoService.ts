import { api } from "./apiService"

type JogoPost = {
    jogoId: number,
    img: File | null,
    nome: string,
    descricao: string,
    preco: number,
    statusJogo: boolean,
    generoIds: string[],
}

interface JogoListagem {
    jogoId: number,
    img: File | null,
    nome: string,
    descricao: string,
    preco: number,
    statusJogo: boolean,
    generoIds: string[],
}

export async function listarJogos() {
    try {
        const response = await api.get("Produto")
        const jogos = response.data.map((jogo: JogoListagem) => ({
            ...jogo,
            ImageUrl: `${api.defaults.baseURL} ${jogo.img}`
        }))

        const produtosAtivos = jogos.data.filter(
            (jogo: JogoListagem) => jogo.statusJogo = true
        )

        return jogos;
    } catch (error : any) {
        throw new Error(error.response.data);
    }
}