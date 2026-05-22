import { api } from "./apiService";

export async function listarClassificacao() {
    const response = await api.get("Classificacao");
    return response.data
}
