import React from 'react'
import styles from '@/pages/login/LoginPage.module.css'

const LoginPage = () => {
    return (
        <main id={styles.main}>
            <div id={styles.container_main} className='layout-grid'>
                <img src="../mulher_login.png" id={styles.img_mulher} alt="Foto de uma mulher alienigena com cabelo preso e marcas vermelhas na pele" />
                <form action="" id={styles.form_login}>
                    <img src="../logo.png" alt="Logo Royal games em vermelho" id={styles.logo} />

                    <div id={styles.inputs}>
                        <div className={styles.content_input}>
                            <label htmlFor="email">Email</label>
                            <input type="text" name='email' placeholder='email@email.com' />
                        </div>

                        <div className={styles.content_input}>
                            <label htmlFor="password">Senha</label>
                            <input type="password" name='password' placeholder='********' />
                        </div>
                    </div>

                    <button>Entrar</button>
                </form>
            </div>
        </main>
    )
}

export default LoginPage 