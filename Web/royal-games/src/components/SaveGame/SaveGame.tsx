import React from 'react'
import styles from '@/components/SaveGame/SaveGame.module.css'

const SaveGame = () => {
    return (
        <section id={styles.save_game}>
            <form action="" id={styles.form_save_game} className='layout-grid'>
                <div id="top">
                    <h2 id={styles.titulo_form}>Cadastrar novo jogo</h2>
                </div>

                <div id={styles.middle} className='layout-grid'>
                    <div id={styles.side1}>
                        <div id={styles.row1}>
                            <div id={styles.inpt1}>
                                <label htmlFor="game-name">Nome</label>
                                <input type="text" name='game-name' />
                            </div>
                        </div>

                        <div id={styles.row2}>
                            <div id={styles.inpt2}>
                                <label htmlFor="game-price">valor</label>
                                <input type="text" name='game-price' id={styles.inpt_price} />
                            </div>

                            <div id={styles.inpt3}>
                                <label htmlFor="game-genre">Gênero</label>
                                <input type="text" name='game-genere' id={styles.inpt_genre} />
                            </div>

                            <div id={styles.inpt4}>
                                <label htmlFor="game-indicative-class">Classificação indicativa</label>
                                <input type="text" name='game-indicative-class' id={styles.inpt_class} />
                            </div>
                        </div>

                        <div id={styles.row3}>
                            <div id={styles.inpt5}>
                                <label htmlFor="game-platform">Plataforma</label>
                                <input type="text" name='game-platform' id={styles.inpt_plat} />
                            </div>

                            <div id={styles.inpt6}>
                                <label htmlFor="game-image">Imagem</label>
                                <input type="text" name='game-image' id={styles.inpt_img} />
                            </div>
                        </div>
                    </div>

                    <div id={styles.side2}>
                        <div id={styles.inpt7}>
                            <label htmlFor="game-description">Descrção</label>
                            <textarea name='game-image' id={styles.textarea}></textarea>
                        </div>
                    </div>
                </div>

                <button>Cadastrar</button>
            </form>
        </section>
    )
}

export default SaveGame