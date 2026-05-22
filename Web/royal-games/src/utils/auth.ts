import secureLocalStorage from "react-secure-storage";

export function verificarAutenticacao() {
    const token = secureLocalStorage.getItem("Token");
    return !!token;

    //Se existir informação dentro do token ele retorna true, se nao false.
}