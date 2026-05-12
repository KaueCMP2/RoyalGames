import React from 'react'
import styles from '@/components/Header/Header.module.css'

const Header = () => {
    return (
        <header id={styles.header}>
            <div id={styles.content_header} className='layout-grid'>
                <img src="../logo.png" alt="Logo Royal games em vermelho" id={styles.logo} />
                <div id={styles.icons_right}>
                    <a href="#jogos">Jogos</a>
                    <a href="#perfil" id={styles.link_perfil}>Perfil</a>
                </div>
            </div>
        </header>
    )
}

export default Header