import { toastConfirmarExclusao } from "@/utils/toasts";
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
        const formData = new FormData()

        formData.append("nome", jogo.nome);
        formData.append("valor", jogo.valor.toString());
        formData.append("descricao", jogo.descricao);

        if (jogo.imagem) {
            formData.append("imagem", jogo.imagem);
        }

        jogo.generoIds.forEach((generoId) => {
            formData.append("generoIds", generoId.toString())
        })

        formData.append("classificacaoIndicativaId", jogo.classificacaoIndicativaId.toString())

        jogo.plataformaIds.forEach((plataformaId) => {
            formData.append("plataformaIds", plataformaId.toString())
        });

        await api.post("Jogo", formData)
        console.log(formData)

    } catch (error: any) {
        throw new Error(error.response?.data);
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

export async function AtualizarJogos(id: number, jogo: JogoFormulario) {
    try {
        const formData = new FormData()

        formData.append("nome", jogo.nome);
        formData.append("valor", jogo.valor.toString());
        formData.append("descricao", jogo.descricao);

        if (jogo.imagem) {
            formData.append("imagem", jogo.imagem);
        }

        jogo.generoIds.forEach((generoId) => {
            formData.append("generoIds", generoId.toString())
        })

        formData.append("classificacaoIndicativaId", jogo.classificacaoIndicativaId.toString())

        jogo.plataformaIds.forEach((plataformaId) => {
            formData.append("plataformaIds", plataformaId.toString())
        });

        await api.put("Jogo/" + id, formData)
        console.log(formData)
    } catch (error: any) {
        console.log(error);

        //! Gerei com o chat essa linha de comando
        throw new Error(
            error.response?.data?.title ||
            error.response?.data ||
            error.message ||
            "Erro ao cadastrar jogo"
        );
    }
}

export async function removerJogo(id: number) {
    try {
        if (id) {
            api.delete("Jogo/" + id);
            toastConfirmarExclusao;
        }
    }
    catch (error: any) {

        console.log(error.response);

        console.log(error.response?.data);

        console.log(error.response?.status);

        throw new Error(
            error.response?.data?.title ||
            error.response?.data ||
            error.message ||
            "Erro ao cadastrar jogo"
        );
    }
}