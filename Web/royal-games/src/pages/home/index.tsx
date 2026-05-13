import Banner from '@/components/Banner/Banner'
import Footer from '@/components/Footer/Footer'
import Header from '@/components/Header/Header'
import SaveGame from '@/components/SaveGame/SaveGame'
import React from 'react'
import styles from '@/pages/home/home.module.css'
import GameList from '@/components/GameList/GameList'

const HomePage = () => {
  return (
    <main id={styles.body}>
      <Header />
      <SaveGame />
      <GameList />

      <section id={styles.quest_section}>
        <h2>Jogos online podem afetar o comportamento humano?</h2>
        <div id={styles.content_quest_section}>
          <div id={styles.cover_game_question}>
            <img src="../game-cover/lol2.png" alt="capa do jogo league of legends" />
            <img src="../game-cover/cs.png" alt="capa do jogo counter strike" />
          </div>
        </div>


        <article>
          <p>Estudos indicam que jogos podem alterar o comportamento humano...</p>
          <p>Principalmente quando o time resolve testar sua paciência em plena partida ranqueada.</p>
        </article>
      </section>

      <Footer />
    </main>
  )
}

export default HomePage