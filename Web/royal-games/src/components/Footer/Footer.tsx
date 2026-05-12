import React from 'react'
import styles from '@/components/Footer/Footer.module.css'

const Footer = () => {
    return (
        <footer id={styles.footer}>
            <div id={styles.content_footer} className='layout-grid'>
                <img src="../logo.png" alt="Logo Royal games em vermelho" id={styles.logo} />

                <div id={styles.container_shop_infos}>
                    <p className={styles.text_info}>royalgames@gmail.com</p>
                    <p className={styles.text_info}>(11) 99999-9999</p>
                    <p className={styles.text_info}>@RoyalGames</p>
                </div>
            </div>
        </footer>
    )
}

export default Footer