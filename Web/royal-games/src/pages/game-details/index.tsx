import Footer from '@/components/Footer/Footer'
import Header from '@/components/Header/Header'
import React from 'react'
import styles from '@/pages/game-details/game-details.module.css'

const GameDetails = () => {
  return (
    <body id={styles.body}>
      <Header />
      <GameDetails />
      <Footer />
    </body>
  )
}

export default GameDetails