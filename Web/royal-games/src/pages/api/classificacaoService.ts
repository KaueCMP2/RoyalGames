import { api } from "./apiService";

export async function listarClassificacao() {
    const response = await api.get("Classificacao");
    console.log(response.data);

    return response.data
}
