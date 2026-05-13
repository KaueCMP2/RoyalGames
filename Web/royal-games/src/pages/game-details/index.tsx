import Footer from '@/components/Footer/Footer'
import Header from '@/components/Header/Header'
import React from 'react'
import styles from '@/pages/game-details/game-details.module.css'
import GameDetails from '@/components/GameDetails/GameDetails'

const Pag_GameDetails = () => {
  return (
    <>
      <Header />
      <GameDetails />
      <Footer />
    </>
  )
}

export default Pag_GameDetails