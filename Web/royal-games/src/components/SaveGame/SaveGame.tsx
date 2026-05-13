import React from 'react'
import styles from '@/components/SaveGame/SaveGame.module.css'

const SaveGame = () => {
    return (
        <section id={styles.save_game}>
            <form action="" id={styles.form_save_game} className='layout-grid'>
                <div id="top">
                    <h2 id={styles.titulo_form}>Cadastrar novo jogo</h2>
                </div>

                <div id="middle">
                    <div id="side1">
                        <label htmlFor="game-name">Nome</label>
                        <input type="text" name='game-name' />

                        <label htmlFor="game-price">valor</label>
                        <input type="text" name='game-price' />
                        
                        <label htmlFor="game-genre">Gênero</label>
                        <input type="text" name='game-genere' />
                        
                        <label htmlFor="game-indicative-class">Classificação indicativa</label>
                        <input type="text" name='game-indicative-class' />
                        
                        <label htmlFor="game-platform">Plataforma</label>
                        <input type="text" name='game-platform' />
                        
                        <label htmlFor="game-image">Imagem</label>
                        <input type="text" name='game-image' />
                    </div>

                    <div id="side2">
                        <label htmlFor="game-description">Descrção</label>
                        <input type="text" name='game-image' />
                    </div>
                </div>

                <button>Cadastrar</button>
            </form>
        </section>
    )
}

export default SaveGame