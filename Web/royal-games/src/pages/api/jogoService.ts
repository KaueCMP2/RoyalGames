import { api } from "./apiService"

type JogoFormulario = {
    jogoId: number,
    nome: string,
    valor: number,
    descricao: string,
    statusJogo: boolean,
    imgUrl: string,
    classificacaoIndicativaId: number;
    generoIds: number[],
}

interface JogoListagem {
    jogoId: number,
    nome: string,
    valor: number,
    descricao: string,
    statusJogo: boolean,
    imgUrl: string,
    plataformaIds: number[],
    classificacaoIndicativaId: number;
    generoIds: number[]
}

export async function listarJogos() {
    try {
        const response = await api.get("Jogo")
        console.log(response.data)

        const jogos = response.data.map((jogo: JogoListagem) => ({
            ...jogo,
            imgUrl: `${api.defaults.baseURL}${jogo.imgUrl}`
        }))

        jogos.forEach((jogo: any) => {
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

export async function listarJogosPorId(id: number) {
    try {
        const response = await api.get("Jogo/" + id)
        console.log(response.data)

        const jogo = {
            ...response.data,
            imgUrl: `${api.defaults.baseURL}${response.data.imgUrl}`
        }

        console.log(response.data.classificacaoIndicativaId);

        return jogo;
    } catch (error: any) {
        throw new Error(error.response.data)
    }
}