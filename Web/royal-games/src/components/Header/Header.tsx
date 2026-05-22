import React, { useEffect, useState } from 'react'
import styles from '@/components/Header/Header.module.css'
import Link from 'next/link'
import secureLocalStorage from 'react-secure-storage';

const Header = () => {
    const [logado, setLogado] = useState("Login")

    useEffect(() => {
        const token = secureLocalStorage.getItem("Token");
        token ? setLogado("Deslogar") : setLogado("Logar");
    }, [])

    return (
        <header id={styles.header}>
            <div id={styles.content_header} className='layout-grid'>
                <img src="../logo.png" alt="Logo Royal games em vermelho" id={styles.logo} />
                <div id={styles.icons_right}>
                    <Link href="/jogo">Jogos</Link>
                    <Link href="/login" id={styles.link_deslog}>{logado}</Link>
                </div>
            </div>
        </header >
    )
}

export default Header