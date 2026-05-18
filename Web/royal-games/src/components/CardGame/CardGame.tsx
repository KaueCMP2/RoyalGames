import React from 'react'
import styles from '@/components/CardGame/CardGame.module.css'
import Link from 'next/link'

type Jogo = {
    jogoId: number,
    imgUrl: string,
    nome: string,
    descricao: string,
    preco: number,
}

export const CardGame = (jogo: Jogo) => {
    return (
        <li id={styles.card}>
            <div id={styles.card_content}>
                <img src={jogo.imgUrl} alt="Capa do jogo minecraft legends" id={styles.game_cover} />
                <div id={styles.container_info_card}>
                    <h3>{jogo.nome}</h3>
                    <p>{jogo.descricao}</p>
                </div>
                <Link href={"/detalhes"} id={styles.link}>Detalhes</Link>
            </div>
        </li>
    )
}
