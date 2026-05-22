import { api } from "./apiService"

type JogoFormulario = {
    nome: string,
    valor: string,
    descricao: string,
    imagem: File | null,
    generoIds: number[],
    classificacaoIndicativaId: number[],
    plataformaIds: number[],
}

interface JogoListagem {
    jogoId: number,
    nome: string,
    valor: number,
    descricao: string,
    statusJogo: boolean,
    imgUrl: string,
    generoIds: number[],
    generos: string[],
    plataformaIds: number[],
    plataformas: string[],
    classificacaoIndicativaId: number,
    classificacaoIndicativa: string[];
}

export async function cadastrarJogos(jogo: JogoFormulario) {
    try {
        console.log("entrou aqui")

        const formData = new FormData()

        formData.append("Nome", jogo.nome);
        formData.append("Valor", jogo.valor);
        formData.append("Descricao", jogo.descricao);

        console.log("passou aqui no final olha!")
        if (jogo.imagem) {
            formData.append("Imagem", jogo.imagem);
        }

        jogo.generoIds.forEach((generoId) => {
            formData.append("GeneroIds", generoId.toString())
        })

        formData.append("ClassificacaoIndicativaId", jogo.classificacaoIndicativaId.toString())

        console.log("no meio tbm!")
        jogo.plataformaIds.forEach((plataformaId) => {
            formData.append("PlataformaIds", plataformaId.toString())
        });

        await api.post("Jogo", formData)
        console.log("passou aqui no final olha!")

    } catch (error: any) {
        throw new Error(error.response.data)
    }
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

        console.log(response.data.plataformaIds);

        return jogo;
    } catch (error: any) {
        throw new Error(error.response.data)
    }
}