import React, { useEffect, useState } from 'react'
import styles from '@/components/GameList/GameList.module.css'
import { CardGame } from '../CardGame/CardGame'
import { listarJogos } from '@/pages/api/jogoService'
import { trackAllowedDynamicAccess } from 'next/dist/server/app-render/dynamic-rendering'

type Jogo = {
    jogoId: number,
    nome: string,
    valor: number,
    descricao: string,
    statusJogo: boolean,
    generoIds: string[],
    imgUrl: string,
}


const GameList = () => {
    const [jogos, SetJogos] = useState<Jogo[]>([]);

    
    async function Listar() {
        try {
            const lista = await listarJogos();
            SetJogos(lista);
        } catch (error: any) {
            console.error(error.message);
        }
    }
    
    console.log(jogos)
    
    useEffect(() => {
        Listar();
    }, [])

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
                        nome={item.nome}
                        imgUrl={item.imgUrl}
                        descricao={item.descricao}
                        preco={item.valor}
                    />
                )) : (
                    <p>Carregando produtos...</p>
                )}

            </ul>
        </section>
    )
}

export default GameList