import React from 'react'
import styles from '@/components/CardGame/CardGame.module.css'

export const CardGame = () => {
    return (
        <li id={styles.card}>
            <div id={styles.card_content}>
                <img src="../game-cover/minecraft_legends.png" alt="Capa do jogo minecraft legends" id={styles.game_cover} />
                <div id={styles.container_info_card}>
                    <h3>Minecraft</h3>
                    <p>R$70,00</p>
                </div>
                <button>Detalhes</button>
            </div>
        </li>
    )
}
