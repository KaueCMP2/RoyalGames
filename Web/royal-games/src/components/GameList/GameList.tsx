import React, { useEffect, useState } from 'react'
import styles from '@/components/GameList/GameList.module.css'
import { CardGame } from '../CardGame/CardGame'
import { listarJogos } from '@/pages/api/jogoService'
import { trackAllowedDynamicAccess } from 'next/dist/server/app-render/dynamic-rendering'

type Jogo = {
    jogoId: number,
    imgUrl: string,
    nome: string,
    descricao: string,
    preco: number
}

const GameList = () => {
    const [jogos, SetJogos] = useState<Jogo[]>([]);
    async function Listar() {
        try {
            const lista = await listarJogos();
            SetJogos(lista);
        } catch (error: any) {
            console.log(error.message);
        }
    }

    useEffect(() => {
        Listar();
    },)

    return (
        <section id='game_list' className={styles.game_list}>
            <h2>Catálogo de jogos</h2>

            <div id={styles.container_search}>
                <input type="text" placeholder="pesquise..." id={styles.search_input} />

                <div id={styles.container_buttons}>
                    <button id={styles.btn_price}>Menor Preço</button>
                    <button id={styles.btn_category}>Categoria</button>
                </div>
            </div>

            <ul id={styles.container_games} className='layout-grid'>
                {jogos.length > 0 ? jogos.map((item) => (
                    <CardGame
                        key={item.jogoId}
                        jogoId={item.jogoId}
                        imgUrl={item.imgUrl}
                        nome={item.nome}
                        descricao={item.descricao}
                        preco={item.preco}
                    />
                )) : (
                    <p>Carregando produtos...</p>
                )}

            </ul>
        </section>
    )
}

export default GameList