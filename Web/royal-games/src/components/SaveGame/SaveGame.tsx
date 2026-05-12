import React from 'react'
import styles from '@/components/SaveGame/SaveGame.module.css'

const SaveGame = () => {
    return (
        <section id={styles.salvar_jogo}>
            <form action="" id={styles.form_salvar_kogo}>
                <div id="top">

                    <h2 id={styles.titulo_form}>Cadastrar Jogo</h2>
                </div>
                <div id="middle">

                    <div id="side1">
                        <label htmlFor="game-name"></label>
                        <input type="text" name='game-name' />
                        <label htmlFor="game-price"></label>
                        <input type="text" name='game-price' />
                        <label htmlFor="game-genre"></label>
                        <input type="text" name='game-genere' />
                        <label htmlFor="game-indicative-class"></label>
                        <input type="text" name='game-indicative-class' />
                        <label htmlFor="game-platform"></label>
                        <input type="text" name='game-platform' />
                        <label htmlFor="game-image"></label>
                        <input type="text" name='game-image' />
                    </div>
                    <div id="side2">
                        <label htmlFor="game-description"></label>
                        <input type="text" name='game-image' />
                    </div>
                </div>

                <div id=''></div>
                <button></button>
            </form>
        </section>
    )
}

export default SaveGame