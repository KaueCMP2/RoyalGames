import React from 'react'
import styles from '@/components/GameDetails/GameDetails.module.css'

const GameDetails = () => {
  return (
    <main id={styles.main}>
      <div id={styles.content_main} className='layout-grid'>
        <h1>Detalhes do jogo</h1>
        <div id={styles.container_game_details}>
          <div id={styles.content_game_details1}>
            <img src="../game-cover/lol.png" alt="" />
            <div id={styles.container_info}>
              <article id={styles.game_article}>
                <h2>League of legends</h2>
                <p>League of Legends (LoL) é um jogo eletrônico do gênero MOBA (Multiplayer Online Battle Arena) onde duas equipes de cinco jogadores competem entre si com o objetivo de destruir a base adversária. Cada jogador controla um campeão com habilidades únicas, exigindo estratégia, trabalho em equipe e tomada de decisões rápidas durante as partidas.
                <br/>
                <br/>
                  O jogo possui diversos modos, mapas e estilos de jogo, além de oferecer atualizações frequentes com novos personagens, eventos e ajustes de balanceamento. League of Legends é conhecido pelo seu cenário competitivo mundial, reunindo milhões de jogadores e campeonatos profissionais ao redor do mundo.</p>
              </article>
              <div id={styles.game_details}>
                <p>Classificação indicativa: 18 anos</p>
                <p>Preço: R$100,00</p>
                <p>Plataformas:</p>
                <p>Categorias:</p>
                <p>Genero:</p>
              </div>
            </div>
          </div>

        </div>
      </div>
    </main >
  )
}

export default GameDetails