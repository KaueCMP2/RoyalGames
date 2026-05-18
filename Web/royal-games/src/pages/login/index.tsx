import React, { useState } from 'react'
import styles from '@/pages/login/LoginPage.module.css'
import { useRouter } from 'next/router';
import { toast } from 'react-toastify';
import { login } from '../api/authService';

const LoginPage = () => {
    const [email, setEmail] = useState<string>("");
    const [senha, setSenha] = useState<string>("");

    const router = useRouter();
    const notificacao = (msg: string) => toast.success(msg);
    const erro = (msg: string) => toast.error(msg);

    async function autenticar(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        try {
            await login(email, senha)
            notificacao("Login bem sucedido")

            setTimeout(() => {
                router.push("/home");
            })
        } catch (error: any) {
            erro(error.message);
        }
    }


    return (
        <main id={styles.main}>
            <div id={styles.container_main} className='layout-grid'>
                <img src="../mulher_login.png" id={styles.img_mulher} alt="Foto de uma mulher alienigena com cabelo preso e marcas vermelhas na pele" />
                <form onSubmit={autenticar} id={styles.form_login}>
                    <img src="../logo.png" alt="Logo Royal games em vermelho" id={styles.logo} />

                    <div id={styles.inputs}>
                        <div className={styles.content_input}>
                            <label htmlFor="email">Email</label>
                            <input type="text" name='email' placeholder='email@email.com' required value={email} onChange={(e) => setEmail(e.target.value)} />
                        </div>

                        <div className={styles.content_input}>
                            <label htmlFor="password">Senha</label>
                            <input type="password" name='password' placeholder='********' required value={senha} onChange={(e) => setSenha(e.target.value)} />
                        </div>
                    </div>

                    <button>Entrar</button>
                </form>
            </div>
        </main>
    )
}

export default LoginPage 