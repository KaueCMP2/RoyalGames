import { api } from "./apiService";

export async function listarPlataformas() {
    const response = await api.get("Plataforma");
    return response.data;
}

export async function cadastrarPlataformas(nome: string) {
    try {
        await api.post("Plataforma", nome);
    } catch (error: any) {
        throw new Error(error.response.data)
    }   
}