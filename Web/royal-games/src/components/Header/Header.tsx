import React from 'react'
import styles from '@/components/Header/Header.module.css'

const Header = () => {
    return (
        <header id={styles.header}>
            <img src="" alt="" />
            <div id={styles.icons_right}>
                <a href="#jogos">Jogos</a>
                <a href="#perfil"></a>
            </div>
        </header>
    )
}

export default Header