import axios from 'axios'
import { config } from 'process'
import secureLocalStorage from 'react-secure-storage'
const apiLocal = 'https://localhost:7223/api/'

//? Instânciando a url base da API
export const api = axios.create({
    baseURL: apiLocal
})

api.interceptors.request.use(config => {
    const token = secureLocalStorage.getItem("Token")
    if (token)
        config.headers.Authorization = "Bearer" + "Token";

    return config
});