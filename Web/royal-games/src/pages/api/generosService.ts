import { api } from "./apiService";

export async function listarGeneros() {
    const response = await api.get("Genero");
    console.log(response.data)

    return response.data
}

export async function cadastrarGeneros(nome: string) {
    try {
        await api.post("Categoria", { nome })
    } catch (error: any) {
        throw new Error(error.response.data);
    }
}