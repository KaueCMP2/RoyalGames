import React, { useState } from 'react'
import styles from '@/components/Header/Header.module.css'
import Link from 'next/link'
import secureLocalStorage from 'react-secure-storage';

const Header = () => {
    const token = secureLocalStorage.getItem("Token");
    const [logado, setLogado] = useState(token ? "Deslogar" : "Login")

    return (
        <header id={styles.header}>
            <div id={styles.content_header} className='layout-grid'>
                <img src="../logo.png" alt="Logo Royal games em vermelho" id={styles.logo} />
                <div id={styles.icons_right}>
                    <Link href="/salvar-jogo">Jogos</Link>
                        <Link href="/login" id={styles.link_deslog}>{logado}</Link>
                </div>
            </div>
        </header >
    )
}

export default Header