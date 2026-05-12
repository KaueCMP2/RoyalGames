import React from 'react'
import styles from '@/components/Banner/Banner.module.css'

const Banner = () => {
    return (
        <section id={styles.banner}>
            <div id={styles.side1}>
                <h2>Conheça nossos jogos!</h2>
                <p>Navegue por títulos de todas as gerações, descubra plataformas, gêneros e detalhes completos antes de escolher sua próxima aventura. Seu próximo jogo favorito começa aqui.</p>
            </div>
            <img src="../mulher_canto.png" alt="Imagem de uma mulher com metade do cabelo trançado e fraja" id={styles.img_mulher} />
        </section>
    )
}

export default Banner