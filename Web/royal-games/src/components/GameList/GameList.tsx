import React from 'react'
import styles from '@/components/GameList/GameList.module.css'

const GameList = () => {
    return (
        <section id={styles.game_list}>
            <h2>Catálogo de jogos</h2>

            <div id={styles.container_search}>
                <input type="text" placeholder='pesquise...' id={styles.search_input} />

                <div id={styles.container_buttons}>
                    <button id={styles.btn_price}>Menor Preço</button>
                    <button id={styles.btn_category}>Categoria</button>
                </div>
            </div>

            <ul id={styles.container_games}>

            </ul>
        </section>
    )
}

export default GameList